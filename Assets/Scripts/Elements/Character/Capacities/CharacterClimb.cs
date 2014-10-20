using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterClimb : CharacterCapacity 
{
	public float climbingSpeed = 10f;

	private void FixedUpdate ()
	{
		if (character.physics.isClimbing) 
		{
			rigidbody.AddForce (Vector3.up * -rigidbody.velocity.y, ForceMode.Impulse);
			rigidbody.AddForce (Vector3.up * character.input.vertical * climbingSpeed, ForceMode.Impulse);
		}
	}
}
