using UnityEditor;
using UnityEngine;
using System.Collections;

//This script automaticaly (on import) disable the mip-map and set the texture type to Advanced.  It also trows an error if the texture hasn't a power-of-two size

public class PostProcessTextures : AssetPostprocessor {
	
   	private void OnPreprocessTexture () 
	{
		TextureImporter textureImporter = assetImporter as TextureImporter;
        textureImporter.textureType = TextureImporterType.Advanced;
		textureImporter.mipmapEnabled = false;
		//textureImporter.npotScale = TextureImporterNPOTScale.None;
    }
	
    private void OnPostprocessTexture (Texture2D texture) 
	{
        string path = AssetDatabase.GetAssetPath(texture);
		
		if (!isPowerOfTwo(texture.width) || !isPowerOfTwo(texture.height)){
			Debug.LogWarning("Texture with non-power-of-two dimension (" + texture.width + "x" + texture.height + ") was import at " + path);
		}
    }
	
	private bool isPowerOfTwo(int x)
	{
		return ((x & (x - 1)) == 0);
	}
}
