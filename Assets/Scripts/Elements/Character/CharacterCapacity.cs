using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterCapacity : MonoBehaviour 
{
	protected Character character;

	protected virtual void Awake()
	{
		character = GetComponent<Character>();
	}
}
