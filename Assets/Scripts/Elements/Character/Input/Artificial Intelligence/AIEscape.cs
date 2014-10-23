using UnityEngine;
using System.Collections;

public class AIEscape : State
{
	private CharacterInputAIEscape aiEscape;

	private void OnEnable()
	{
		this.aiEscape = GetComponent<CharacterInputAIEscape>();
		this.aiEscape.enabled = true;
	}
	
	private void Update () 
	{
		
	}
	
	private void OnDisable()
	{
		this.aiEscape.enabled = false;
	}
}
