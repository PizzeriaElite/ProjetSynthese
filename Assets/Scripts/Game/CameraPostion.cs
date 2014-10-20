using UnityEngine;
using System.Collections;

public class CameraPostion : MonoBehaviour 
{
	const float DEFAULT_SMOOTING_TIME = 0.2f;
	public GameObject CameraTarget = null;
	public float CameraDepth = -8f;
	public float RadiusOfAcceptableCentre = 1f;
	public float smoothingTime = DEFAULT_SMOOTING_TIME;
	private Vector3 cameraVelocity = Vector3.zero;
	private bool mustCentre = false;
	

	void Start ()
	{
		if (this.CameraTarget != null)
		{
			Camera.main.transform.position = new Vector3(this.CameraTarget.transform.position.x, this.CameraTarget.transform.position.y, this.CameraDepth );
		}
	}

	void Update () 
	{
		if (this.CameraTarget != null)
		{
			// Set the centre of the camera on the target
			if (Vector2.Distance(Camera.main.transform.position, this.CameraTarget.transform.position) > this.RadiusOfAcceptableCentre)
			{
				this.mustCentre = true;
			}
			if (Vector2.Distance (Camera.main.transform.position, CameraTarget.transform.position) == 0)
			{
				this.mustCentre = false;
			}

			if (this.mustCentre == true)
			{
				Debug.Log("Centering");
				Vector3 centeringTargetPostion = new Vector3(this.CameraTarget.transform.position.x, this.CameraTarget.transform.position.y, this.CameraDepth );

				Camera.main.transform.position = Vector3.SmoothDamp(Camera.main.transform.position, centeringTargetPostion, ref this.cameraVelocity, this.smoothingTime);
			}
		}
	}
}
