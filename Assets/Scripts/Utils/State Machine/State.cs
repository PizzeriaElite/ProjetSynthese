using UnityEngine;
using System.Collections;

public class State : MonoBehaviour 
{
	private float enterTime = Mathf.Infinity;
	private float exitTime = Mathf.Infinity;
	
	public float TimeSinceEnter { get { return Time.time - enterTime; }}
	public float TimeSinceExit  { get { return Time.time - exitTime;  }}

	public virtual void Enter()
	{
		enterTime = Time.time;
		this.enabled = true;
	}
	
	public virtual void Exit()
	{
		exitTime = Time.time;
		this.enabled = false;
	}
	
	protected virtual void Start()
	{
		
	}
}
