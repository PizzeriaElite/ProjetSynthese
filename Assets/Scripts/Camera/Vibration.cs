using UnityEngine;
using System.Collections;

public class Vibration: MonoBehaviour 
{
	
	private float VibrationRange = 0.3f;
	private float VibrationDuration = 0.5f;

	private float timeOfEndVibration;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time < this.timeOfEndVibration)
		{
			Vector3 cameraPosition = Camera.main.transform.position;
			
			float newX = cameraPosition.x + Random.Range(-this.VibrationRange,this.VibrationRange);
			float newY = cameraPosition.y + Random.Range(-this.VibrationRange,this.VibrationRange);
			float newZ = cameraPosition.z + Random.Range(-this.VibrationRange,this.VibrationRange);
			
			Vector3 newCameraPosition = new Vector3(newX,newY,newZ);
			
			Camera.main.transform.position = newCameraPosition;
			
			Debug.Log ("Vibration:: X:" + newX.ToString() +  "Y: " +  newY.ToString() + "Z: " + newZ.ToString());
		}
	}

	
	public void Vibrate(float range, float duration)
	{
		this.timeOfEndVibration = Time.time + this.VibrationDuration;
		this.VibrationRange = range;
		this.VibrationDuration = duration;
	}
}
