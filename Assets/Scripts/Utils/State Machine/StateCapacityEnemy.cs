using UnityEngine;
using System.Collections;

public class StateCapacityEnemy : State 
{
	protected CharacterEnemy character;
	
	protected virtual void Awake()
	{
		character = transform.parent.GetComponent<CharacterEnemy>();
	}
}
