using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterPhysics : CharacterCapacity 
{
	public bool debugNoClip = false;
	[System.NonSerialized] public bool isGrounded;
	[System.NonSerialized] public bool isClimbing;

	void OnTriggerStay(Collider other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Ladder")
		{
			Debug.Log ("plz2");
			isClimbing = true;
			character.rigidbody.useGravity = false;
		} 
	}
	
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Ladder")
		{
			isClimbing = false;
			character.rigidbody.useGravity = true;
		}
	}
}
