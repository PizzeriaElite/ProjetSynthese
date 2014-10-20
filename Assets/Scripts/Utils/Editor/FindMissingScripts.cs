using UnityEngine;
using UnityEditor;

public class FindMissingScripts : EditorWindow {
 
    [MenuItem("Window/FindMissingScripts")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(FindMissingScripts));
    }
 
    public void OnGUI()
    {
        if (GUILayout.Button("Find Missing Scripts in selected prefabs"))
        {
            FindInSelected();
        }
		if (GUILayout.Button("Find Missing Scripts in scene"))
        {
            FindInScene();
        }
    }
	
	private static void Find(GameObject[] gameObjects)
    {
        int go_count = 0, components_count = 0, missing_count = 0;
        
		foreach (GameObject g in gameObjects)
        {
            go_count++;
            Component[] components = g.GetComponents<MonoBehaviour>();
            
			for (int i = 0; i < components.Length; i++)
            {
                components_count++;
                if (components[i] == null)
                {
                    missing_count++;
                    Debug.Log(g.name + " has an empty script attached in position: " + i, g);
                }
            }
        }
 
        Debug.Log(string.Format("Searched {0} GameObjects, {1} components, found {2} missing", go_count, components_count, missing_count));
    }
    
	private static void FindInSelected()
    {
        Find(Selection.gameObjects);
    }
    
	private static void FindInScene()
    {
        Find((GameObject[]) Object.FindObjectsOfType(typeof(GameObject)));
    }
}