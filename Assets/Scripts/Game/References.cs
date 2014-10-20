using UnityEngine;
using System.Collections;

public class References : MonoBehaviour
{
	public Level level;
	public LevelAI levelAI;
	
	private void Awake()
	{
		Scene.references = this;
	}
}
