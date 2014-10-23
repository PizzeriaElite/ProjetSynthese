using UnityEngine;
using System.Collections;

public class CharacterInputAIIdle : CharacterInput
{	
	private void Update()
	{
		this.character.input.horizontal = 0;
	}
	
	//Code tres rudimentaire a changer
	private void FixedUpdate () 
	{

	}
}
