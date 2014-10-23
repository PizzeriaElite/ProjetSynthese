using UnityEngine;
using System.Collections;

public class AIAgressive : State
{
	private CharacterInputAIFollow aiFollow;

	private void OnEnable()
	{
		this.aiFollow = GetComponent<CharacterInputAIFollow>();
		this.aiFollow.enabled = true;
	}

	private void Update () 
	{

	}

	private void OnDisable()
	{
		this.aiFollow.enabled = false;
	}
}
