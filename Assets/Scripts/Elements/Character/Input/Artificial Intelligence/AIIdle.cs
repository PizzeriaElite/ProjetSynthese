using UnityEngine;
using System.Collections;

public class AIIdle : State
{
	private CharacterInputAIIdle aiIdle;

	private void OnEnable()
	{
		this.aiIdle = GetComponent<CharacterInputAIIdle>();
		this.aiIdle.enabled = true;
	}
	
	private void Update () 
	{
		
	}
	
	private void OnDisable()
	{
		this.aiIdle.enabled = false;
	}
}
