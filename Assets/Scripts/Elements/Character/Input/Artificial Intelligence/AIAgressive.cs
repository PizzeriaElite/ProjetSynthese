using UnityEngine;
using System.Collections;

public class AIAgressive : State
{
	private CharacterInputAIFollow aiFollow;

	private void Start()
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
