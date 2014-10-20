using UnityEditor;
using UnityEngine;
using System.Collections;

//This class set the scale factor of each imported FBX to 1

public class ScaleFBXto1 : AssetPostprocessor {
    
	private float globalScaleModifier = 1f;
    
    private void OnPreprocessModel() {
        ModelImporter importer = (ModelImporter)assetImporter;
        importer.globalScale  = globalScaleModifier;
    }
	
}
