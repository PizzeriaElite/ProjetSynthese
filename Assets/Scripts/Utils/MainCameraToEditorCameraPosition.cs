using UnityEngine;
using System.Collections;
using UnityEditor;

public class MainCameraToEditorCameraPosition : MonoBehaviour {

	[MenuItem ("ENDI/Camera/Main Camera to Editor Camera Position %6")]
	private static void Activate () {
		if (Camera.current != null)	{
			Camera.mainCamera.transform.position = Camera.current.transform.position;
			Camera.mainCamera.transform.rotation = Camera.current.transform.rotation;
		}
	}
}
