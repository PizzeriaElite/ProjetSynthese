using UnityEngine;
using System.Collections;

//Makes the object target not be destroyed automatically when loading a new scene.

public class DontDestroyOnLoad : MonoBehaviour 
{
	void Start () 
	{
		DontDestroyOnLoad(this);
	}
}
