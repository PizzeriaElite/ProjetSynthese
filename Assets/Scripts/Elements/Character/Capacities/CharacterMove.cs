using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMove : CharacterCapacity 
{
	public float speed;

	private void FixedUpdate () 
	{
		if (base.character.physics.debugNoClip)
		{
			NoClipModeActivation();
		}
		else
		{
			NoClipModeDeactivation();
		}
		rigidbody.AddForce(Vector3.right * -rigidbody.velocity.x, ForceMode.Impulse);
		rigidbody.AddForce(Vector3.right * character.input.horizontal * speed, ForceMode.Impulse);
	}

	private void NoClipModeActivation()
	{
		rigidbody.useGravity = false;
		rigidbody.collider.enabled = false;
		rigidbody.AddForce(Vector3.up * -rigidbody.velocity.y, ForceMode.Impulse);
		rigidbody.AddForce(Vector3.up * character.input.vertical * speed, ForceMode.Impulse);
	}

	private void NoClipModeDeactivation()
	{
		rigidbody.useGravity = true;
		rigidbody.collider.enabled = true;
	}
}
