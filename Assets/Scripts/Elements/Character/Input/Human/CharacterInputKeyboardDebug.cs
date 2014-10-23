#define DEBUG

using UnityEngine;
using System.Collections;

public class CharacterInputKeyboardDebug : CharacterInput
{
	private const KeyCode NO_CLIP_TOGGLE_KEY = KeyCode.F;
	
	#if DEBUG
	private void Update () 
	{
		UpdateDebugControls();
	}
	
	private void UpdateDebugControls()
	{
		if (Input.GetKeyDown(NO_CLIP_TOGGLE_KEY))
		{
			this.character.physics.NoClipActivation(!this.character.physics.debugNoClip);
		}
	}
	#endif
}
