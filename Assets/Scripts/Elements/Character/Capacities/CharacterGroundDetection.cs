using UnityEngine;
using System.Collections;

public class CharacterGroundDetection : MonoBehaviour 
{
	public Character character;

	void OnTriggerStay(Collider other)
	{
		character.physics.isGrounded = true;
	}
	
	void OnTriggerExit(Collider other) 
	{
		character.physics.isGrounded = false;
	}
}
