using UnityEditor;
using UnityEngine;
using System.Collections;

public class PostProcessMeshes : AssetPostprocessor {

 
	private void OnPostprocessModel(){
	
		Debug.LogWarning("test");
		
		LogWarning("test2");
		
	}
	
    private void OnPreprocessModel() 
	{
        //ModelImporter importer = (ModelImporter)assetImporter;
        
    }
	
}
