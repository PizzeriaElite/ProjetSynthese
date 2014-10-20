﻿using UnityEngine;
using System.Collections;

public class CharacterInputKeyboardWASD : CharacterInput
{
	private const KeyCode DOWN = KeyCode.S;
	private const KeyCode UP = KeyCode.W;
	private const KeyCode LEFT = KeyCode.A;
	private const KeyCode RIGHT = KeyCode.D;
	private const KeyCode JUMP = KeyCode.W;
	private const KeyCode ACTION = KeyCode.Space;

	/* 
	 * THE REMANING OF THE FILE IS A COPY OF CHARACTERINPUTPCARROWS
	 * 
	 */

	#region Copy of CharacterInputPCArrows
	private void Update () 
	{
		UpdateHorizontal();
		UpdateVertical();
		UpdateDebugFunctions();

		jump       = Input.GetKey(JUMP);
		action     = Input.GetKey(ACTION);
	}

	private void UpdateVertical()
	{
		if (Input.GetKey(DOWN))
		{
			if (vertical != -1)
			{
				vertical = -1;
			}
		}
		else
		if (Input.GetKey(UP))
		{
			if (vertical != 1)
			{
				vertical = 1;
			}
		}
		else
		{
			if (vertical != 0)
			{
				vertical = 0;
			}
		}
	}

	private void UpdateHorizontal()
	{
		if (Input.GetKey(LEFT))
		{
			if (horizontal != -1)
			{
				horizontal = -1;
			}
		}
		else
		if (Input.GetKey(RIGHT))
		{
			if (horizontal != 1)
			{
				horizontal = 1;
			}
		}
		else
		{
			if (horizontal != 0)
			{
				horizontal = 0;
			}
		}
	}
	#endregion

	private void UpdateDebugFunctions()
	{
		if(Input.GetKeyDown("f")) {
			this.character.physics.debugNoClip = !this.character.physics.debugNoClip;
		}
	}
}
