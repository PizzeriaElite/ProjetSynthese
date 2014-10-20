using UnityEngine;
using System.Collections;

public class CharacterInput : CharacterCapacity 
{
	[System.NonSerialized] public float vertical;
	[System.NonSerialized] public float horizontal;
	[System.NonSerialized] public bool  jump;
	[System.NonSerialized] public bool  action;
}
