using UnityEngine;
using System.Collections;

public class AIWandering : State
{
	private CharacterInputAIWandering aiWandering;
	private void Start()
	{
		this.aiWandering = GetComponent<CharacterInputAIWandering>();
		this.aiWandering.enabled = true;
	}
	
	private void Update () 
	{
		
	}
	
	private void OnDisable()
	{
		this.aiWandering.enabled = false;
	}
}
