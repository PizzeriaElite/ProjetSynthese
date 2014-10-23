#define DEBUG
using UnityEngine;
using System.Collections;

public class FollowTargets : MonoBehaviour 
{
	const float DEFAULT_SMOOTING_TIME = 0.2f;
	public GameObject[] CameraTargets = null;
	public float CameraDepth = -8f;
	public float RadiusOfAcceptableCentre = 1f;
	public float smoothingTime = DEFAULT_SMOOTING_TIME;
	public float extremumDistancePadding = 8;
	public float extremumBoxPadding = 0.5f;

	private Vector3 cameraVelocity = Vector3.zero;
	private bool mustCentre = true;
	private Rect rectOfNoCenteringOutsideBound;
	private Rect rectOfNoCenteringInsideBound;
	private float tolerateImpressision = 0.1f;
	

	void Start ()
	{
		if (CameraTargets.Length != 0)
		{
			float minX = float.MinValue;
			float maxX = float.MinValue;
			float minY = float.MinValue;
			float maxY = float.MinValue;
			this.GetExtremum(out minX,out maxX,out minY,out maxY);
			float centreX = minX + ((maxX - minX)/2);
			float centreY = minY + ((maxY - minY)/2);

			Vector3 startPosition = new Vector3(centreX, centreY, this.CameraDepth);

			Debug.Log("Start :" + startPosition.ToString());
			Camera.main.transform.position = startPosition;
			this.GetRectangleOfNoCentering(new Rect(minX,minY,maxX-minX,maxY-minY));
			this.mustCentre = false;
		}
	}

	void GetExtremum(out float minX, out float maxX, out float minY, out float maxY)
	{
		minX = float.MinValue;
		maxX = float.MinValue;
		minY = float.MinValue;
		maxY = float.MinValue;
		if (CameraTargets.Length != 0)
		{
			foreach (GameObject target in CameraTargets) 
			{
				if (target != null)
				{
					Vector3 position = target.transform.position;
					if (minX == float.MinValue)//The first time we enter the loop.
					{
						//We set with the smallest value possible, since the level will be all positive.
						minX = position.x;
						maxX = minX;
						minY = position.y;
						maxY = minY;
					}
					else
					{
						//We take the extrem values.
						minX = Mathf.Min(minX, position.x);
						maxX = Mathf.Max(maxX, position.x);
						minY = Mathf.Min(minY, position.y);
						maxY = Mathf.Max(maxY, position.y);
					}
				}
			}
			// On ajoute un petit surplus pour pas que 
			minX -= this.extremumBoxPadding;
			minY -= this.extremumBoxPadding;
			maxX += this.extremumBoxPadding;
			maxY += this.extremumBoxPadding;
		}
	}

	void Update () 
	{
		if (CameraTargets.Length != 0)
		{
			
			float minX = float.MinValue;
			float maxX = float.MinValue;
			float minY = float.MinValue;
			float maxY = float.MinValue;
			this.GetExtremum(out minX,out maxX,out minY,out maxY);

			float distanceBetweenExtremumX = maxX - minX + this.extremumDistancePadding;
			float distanceBetweenExtremumY = maxY - minY + this.extremumDistancePadding;

			float heightOfViewDesired =  Mathf.Max(distanceBetweenExtremumX / Camera.main.aspect, distanceBetweenExtremumY);
			float widthOfViewDesired = heightOfViewDesired * Camera.main.aspect;
			
			float newCameraDistance = -heightOfViewDesired/(2f*Mathf.Tan(0.5f*Mathf.Deg2Rad*Camera.main.fieldOfView));

			Rect rectOfExtremum = new Rect(minX,minY,maxX-minX,maxY-minY);
			this.GetRectangleOfNoCentering(rectOfExtremum);
			//float neededFieldOfViewAngle = Mathf.Rad2Deg*Mathf.Atan(2f*((0.5f*distanceBetweenExtremumX)/Mathf.Abs(this.CameraDepth-2)));

#if DEBUG


			this.DrawRectangle(rectOfExtremum, Color.blue);
			Rect rectOfCameraViewWanted = new Rect(minX - (this.extremumDistancePadding/2f),minY - (this.extremumDistancePadding/2f),widthOfViewDesired,heightOfViewDesired);
			//this.DrawRectangle(rectOfCameraViewWanted, Color.green);

#endif


			if (this.RectangleIntersect(rectOfExtremum, this.rectOfNoCenteringOutsideBound)||this.RectangleIntersect(rectOfExtremum, this.rectOfNoCenteringInsideBound))//if ( !rectOfExtremum.Overlaps(this.rectOfNoCentering, true))
			{
				this.mustCentre = true;
			}
			if (this.mustCentre && Mathf.Abs(rectOfExtremum.center.x - Camera.main.transform.position.x) < this.tolerateImpressision && Mathf.Abs(rectOfExtremum.center.y - Camera.main.transform.position.y) < this.tolerateImpressision)
			{
				this.mustCentre = false;
			}
			if (this.mustCentre)
			{
				//Central point.
				float centreX = minX + ((maxX - minX)/2);
				float centreY = minY + ((maxY - minY)/2);
				
				//Angle between the most distant target
				//float angle = Vector3.Angle(vectorMin, vectorMax);
				//Debug.Log ("angle:" + angle.ToString());
				Vector3 centeringTargetPosition = new Vector3(centreX, centreY, Mathf.Min(this.CameraDepth, newCameraDistance+1) );
				Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, centeringTargetPosition, ref this.cameraVelocity, this.smoothingTime);
			}
			//Camera.main.fieldOfView = neededFieldOfViewAngle;
		}

	}

	void GetRectangleOfNoCentering(Rect rectOfExtremum)
	{
		if (this.mustCentre == true)
		{
			this.rectOfNoCenteringOutsideBound = new Rect(rectOfExtremum.position.x - this.RadiusOfAcceptableCentre, 
						                                  rectOfExtremum.position.y - this.RadiusOfAcceptableCentre, 
						                                  rectOfExtremum.width + this.RadiusOfAcceptableCentre*2f, 
						                                  rectOfExtremum.height + this.RadiusOfAcceptableCentre*2f);
		

			float insideBoundWidth = Mathf.Max(0f,rectOfExtremum.width  -extremumBoxPadding*2f -  this.RadiusOfAcceptableCentre*2f);
			float insideBoundHeight =  Mathf.Max(0f,rectOfExtremum.height -extremumBoxPadding*2f - this.RadiusOfAcceptableCentre*2f);

			float insideBoundX = 0f;
			float insideBoundY = 0f;

			if (insideBoundWidth == 0f)
			{
				insideBoundX = rectOfExtremum.xMin +0.1f;
				insideBoundWidth = rectOfExtremum.width-0.2f;
			}
			else
			{
				insideBoundX = rectOfExtremum.position.x + extremumBoxPadding + this.RadiusOfAcceptableCentre;
			}

			if (insideBoundHeight == 0f)
			{
				insideBoundY = rectOfExtremum.yMin+0.1f;
				insideBoundWidth = rectOfExtremum.height-0.2f;
			}
			else
			{
				insideBoundY = rectOfExtremum.position.y + extremumBoxPadding + this.RadiusOfAcceptableCentre;
			}

			this.rectOfNoCenteringInsideBound = new Rect(insideBoundX,insideBoundY,insideBoundWidth,insideBoundHeight);

//			this.rectOfNoCenteringInsideBound = new Rect(rectOfExtremum.position.x + extremumBoxPadding + this.RadiusOfAcceptableCentre, 
//			                                             rectOfExtremum.position.y + extremumBoxPadding + this.RadiusOfAcceptableCentre, 
//			                                             Mathf.Max(0,rectOfExtremum.width  -extremumBoxPadding*2f -  this.RadiusOfAcceptableCentre*2f), 
//			                                             Mathf.Max(0,rectOfExtremum.height -extremumBoxPadding*2f - this.RadiusOfAcceptableCentre*2f));
		}
		DrawRectangle(this.rectOfNoCenteringOutsideBound, Color.cyan);
		DrawRectangle(this.rectOfNoCenteringInsideBound, Color.yellow);

	}
#if DEBUG
	//
	struct Segment
	{
		public Vector2 PointA;
		public Vector2 PointB;

		public Segment (Vector2 pointA, Vector2 pointB) 
		{
			PointA = pointA;
			PointB = pointB;
		}
	}
	bool  RectangleIntersect(Rect rect1, Rect rect2)
	{
		Segment rect1Top = new Segment(new Vector2(rect1.xMin, rect1.yMax), new Vector2(rect1.xMax, rect1.yMax));
		Segment rect1Bottom = new Segment(new Vector2(rect1.xMin, rect1.yMin), new Vector2(rect1.xMax, rect1.yMin));
		Segment rect1Left = new Segment (new Vector2(rect1.xMin, rect1.yMin), new Vector2(rect1.xMin, rect1.yMax));
		Segment rect1Right =  new Segment (new Vector2(rect1.xMax, rect1.yMin), new Vector2(rect1.xMax, rect1.yMax));

		Segment rect2Top = new Segment(new Vector2(rect2.xMin, rect2.yMax), new Vector2(rect2.xMax, rect2.yMax));
		Segment rect2Bottom = new Segment(new Vector2(rect2.xMin, rect2.yMin), new Vector2(rect2.xMax, rect2.yMin));
		Segment rect2Left = new Segment (new Vector2(rect2.xMin, rect2.yMin), new Vector2(rect2.xMin, rect2.yMax));
		Segment rect2Right =  new Segment (new Vector2(rect2.xMax, rect2.yMin), new Vector2(rect2.xMax, rect2.yMax));

		bool T1R2 = LinesIntersect(rect1Top.PointA, rect1Top.PointB, rect2Right.PointA, rect2Right.PointB);
		bool T1L2 = LinesIntersect(rect1Top.PointA, rect1Top.PointB, rect2Left.PointA, rect2Left.PointB);
		bool B1R2 = LinesIntersect(rect1Bottom.PointA, rect1Bottom.PointB, rect2Right.PointA, rect2Right.PointB);
		bool B1L2 = LinesIntersect(rect1Bottom.PointA, rect1Bottom.PointB, rect2Left.PointA, rect2Left.PointB); 

		bool T2R1 = LinesIntersect(rect2Top.PointA, rect2Top.PointB, rect1Right.PointA, rect1Right.PointB);
		bool T2L1 = LinesIntersect(rect2Top.PointA, rect2Top.PointB, rect1Left.PointA, rect1Left.PointB);
		bool B2R1 = LinesIntersect(rect2Bottom.PointA, rect2Bottom.PointB, rect1Right.PointA, rect1Right.PointB);
		bool B2L1 = LinesIntersect(rect2Bottom.PointA, rect2Bottom.PointB, rect1Left.PointA, rect1Left.PointB); 
		if (T1R2 || T1L2 || B1R2 || B1L2 || T2R1 || T2L1 || B2R1 || B2L1 )
		{
			Debug.Log("Intersection");
		}

		return T1R2 || T1L2 || B1R2 || B1L2 || T2R1 || T2L1 || B2R1 || B2L1 ;
	}

	//http://ideone.com/PnPJgb
	bool LinesIntersect(Vector2 A, Vector2 B, Vector2 C, Vector2 D)
	{
		Vector2 v = new Vector2();

		Vector2 CmP = new Vector2(C.x - A.x, C.y - A.y);
		Vector2 r = new Vector2(B.x - A.x, B.y - A.y);
		Vector2 s = new Vector2(D.x - C.x, D.y - C.y);
		
		float CmPxr = CmP.x * r.y - CmP.y * r.x;
		float CmPxs = CmP.x * s.y - CmP.y * s.x;
		float rxs = r.x * s.y - r.y * s.x;
		
		if (CmPxr == 0f)
		{
			// Lines are collinear, and so intersect if they have any overlap
			return ((C.x - A.x < 0f) != (C.x - B.x < 0f))
				|| ((C.y - A.y < 0f) != (C.y - B.y < 0f));
		}
		
		if (rxs == 0f)
		{
			return false; // Lines are parallel.
		}
		
		float rxsr = 1f / rxs;
		float t = CmPxs * rxsr;
		float u = CmPxr * rxsr;

		return (t >= 0f) && (t <= 1f) && (u >= 0f) && (u <= 1f);
	}
	void DrawRectangle(Rect rectToDraw, Color colour)
	{
		Vector3 topLeft = rectToDraw.position;
		Vector3 topRight = new Vector3(rectToDraw.position.x + rectToDraw.width, rectToDraw.position.y);
		Vector3 bottomLeft = new Vector3(rectToDraw.position.x, rectToDraw.position.y + rectToDraw.height);
		Vector3 bottomRight = new Vector3(rectToDraw.position.x + rectToDraw.width, rectToDraw.position.y + rectToDraw.height);

		Debug.DrawLine(topLeft, topRight, colour);
		Debug.DrawLine(topLeft, bottomLeft, colour);
		Debug.DrawLine(bottomLeft, bottomRight, colour);
		Debug.DrawLine(topRight, bottomRight, colour);
		Debug.DrawLine(topLeft,bottomRight, colour);
	}
#endif
}
