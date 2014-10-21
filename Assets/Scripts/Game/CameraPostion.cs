#define DEBUG
using UnityEngine;
using System.Collections;

public class CameraPostion : MonoBehaviour 
{
	const float DEFAULT_SMOOTING_TIME = 0.2f;
	public GameObject[] CameraTargets = null;
	public float CameraDepth = -8f;
	public float RadiusOfAcceptableCentre = 1f;
	public float smoothingTime = DEFAULT_SMOOTING_TIME;
	private Vector3 cameraVelocity = Vector3.zero;
	private bool mustCentre = false;
	public float extremumDistancePadding = 8;
	

	void Start ()
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
		}
	}

	void Update () 
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
		//float neededFieldOfViewAngle = Mathf.Rad2Deg*Mathf.Atan(2f*((0.5f*distanceBetweenExtremumX)/Mathf.Abs(this.CameraDepth-2)));

#if DEBUG
		Rect rectOfExtremum = new Rect(minX,minY,maxX-minX,maxY-minY);
		this.DrawRectangle(rectOfExtremum, Color.blue);

		Rect rectOfCameraViewWanted = new Rect(minX - (this.extremumDistancePadding/2f),minY - (this.extremumDistancePadding/2f),widthOfViewDesired,heightOfViewDesired);
		//this.DrawRectangle(rectOfCameraViewWanted, Color.green);

#endif
		//Central point.
		float centreX = minX + ((maxX - minX)/2);
		float centreY = minY + ((maxY - minY)/2);

		//Angle between the most distant target
		//float angle = Vector3.Angle(vectorMin, vectorMax);
		//Debug.Log ("angle:" + angle.ToString());
		Vector3 centeringTargetPostion = new Vector3(centreX, centreY, Mathf.Min(this.CameraDepth, newCameraDistance+1) ); //
		Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, centeringTargetPostion, ref this.cameraVelocity, this.smoothingTime);

//		Camera.main.fieldOfView = Mathf.Max(angle,60f);
		//Camera.main.fieldOfView = neededFieldOfViewAngle;

	}
#if DEBUG
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
