using UnityEngine;
using System.Collections;

public class CharacterInputKeyboardArrows : CharacterInput
{
	private const KeyCode DOWN = KeyCode.DownArrow;
	private const KeyCode UP = KeyCode.UpArrow;
	private const KeyCode LEFT = KeyCode.LeftArrow;
	private const KeyCode RIGHT = KeyCode.RightArrow;
	private const KeyCode JUMP = KeyCode.UpArrow;
	private const KeyCode ACTION = KeyCode.Mouse0;

	private void Update () 
	{
		UpdateHorizontal();
		UpdateVertical();

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
}
