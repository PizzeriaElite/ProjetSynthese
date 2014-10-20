using UnityEngine;
using System;
using System.Collections.Generic;

public class StateMachineComponentEnemy : StateMachineComponent
{
	protected CharacterEnemy character;
	
	protected virtual void Awake()
	{
		character = transform.parent.GetComponent<CharacterEnemy>();
	}
}