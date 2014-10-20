using UnityEngine;
using UnityEditor;

//[ExecuteInEditMode]
public class ResetSceneCameraRotation : ScriptableObject
{
    [MenuItem("ENDI/Reset Scene Camera Rotation &z")]
    static public void resetSceneCameraRotation()
    {
		SceneView.lastActiveSceneView.rotation = Quaternion.identity;
		SceneView.lastActiveSceneView.Repaint();
    }
}
