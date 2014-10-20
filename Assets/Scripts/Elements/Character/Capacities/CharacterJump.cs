using UnityEngine;
using System.Collections;

public class CharacterJump : CharacterCapacity  
{
	private float timeStamp;
	public float jumpHeight;
	[System.NonSerialized] public float jumpCounter;
	public float maxJumpNumber = 2;

	private void Start ()
	{
		jumpCounter = 0;
	}

	private void Update () 
	{

		if (character.physics.isGrounded && timeStamp <= Time.time) 
		{
			jumpCounter = 0;
		}

		if (character.input.jump) 
		{
			if (jumpCounter < maxJumpNumber) 
			{
				timeStamp = Time.time + 0.5f;
				rigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
				jumpCounter++;
				Debug.Log(jumpCounter);
			}
		}
	}
}
