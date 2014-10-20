using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMove : CharacterCapacity 
{
	public float speed;

	private void FixedUpdate () 
	{
		rigidbody.AddForce(Vector3.right * -rigidbody.velocity.x, ForceMode.Impulse);
		rigidbody.AddForce(Vector3.right * character.input.horizontal * speed, ForceMode.Impulse);
	}
}
