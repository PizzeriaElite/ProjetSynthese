using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public TextAsset levelFile;

	public delegate void LevelLoad();
	public static event LevelLoad onLevelLoad;

	void Start ()
	{
		LoadLevel(levelFile);
	}

	private void LoadLevel(TextAsset level)
	{

	}
}
