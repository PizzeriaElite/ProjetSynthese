using UnityEngine;
using System.Collections;

public class CharacterInputAIIdle : CharacterInput
{
	public int ENEMY_SPEED = 10;
	public float MAX_DISTANCE = 5f;
	public float MIN_DISTANCE = 0.5f;
	
	private void Start()
	{
		this.character.input.horizontal = 0;
	}
	
	//Code tres rudimentaire a changer
	private void FixedUpdate () 
	{

	}
}
