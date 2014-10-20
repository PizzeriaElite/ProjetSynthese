using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterPlayer : Character 
{
	protected override void InitializeLists()
	{
		base.InitializeLists();
		
		allPlayers.Add(this);
	}
}
