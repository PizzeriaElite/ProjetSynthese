using UnityEngine;
using System.Collections;
using UnityEditor;

public class GuiTexturePixelInsetTransformPositionConverter : MonoBehaviour 
{
	[MenuItem ("ENDI/GuiTexture/Convert pixelInset.x to transform.Position.x")]
	public static void ConvertPixelInsetXToTransformPositionX () 
	{
		foreach(GameObject go in Selection.gameObjects)
		{
			foreach(GUITexture gt in go.GetComponentsInChildren<GUITexture>())
			{
				gt.transform.position = new Vector3(go.guiTexture.pixelInset.x / PlayerSettings.defaultScreenWidth, 
					                                go.transform.position.y,
					                                go.transform.position.z);
				
				gt.guiTexture.pixelInset = new Rect(0,
					                                go.guiTexture.pixelInset.y,
													go.guiTexture.pixelInset.width,
													go.guiTexture.pixelInset.height);
			}
		}
	}
	
	[MenuItem ("ENDI/GuiTexture/Convert pixelInset.y to transform.Position.y")]
	public static void ConvertPixelInsetYToTransformPositionY () 
	{
		foreach(GameObject go in Selection.gameObjects)
		{
			foreach(GUITexture gt in go.GetComponentsInChildren<GUITexture>())
			{
				gt.transform.position = new Vector3(go.transform.position.x, 
					                                go.guiTexture.pixelInset.y / PlayerSettings.defaultScreenHeight,
					                                go.transform.position.z);
				
				gt.pixelInset = new Rect(go.guiTexture.pixelInset.x,
					                                0,
													go.guiTexture.pixelInset.width,
													go.guiTexture.pixelInset.height);
			}
		}
	}
	
	[MenuItem ("ENDI/GuiTexture/Convert transform.Position.x to pixelInset.x")]
	public static void ConvertTransformPositionXToPixelInsetX () 
	{
		foreach(GameObject go in Selection.gameObjects)
		{
			foreach(GUITexture gt in go.GetComponentsInChildren<GUITexture>())
			{
				gt.guiTexture.pixelInset = new Rect(go.transform.position.x * PlayerSettings.defaultScreenWidth,
					                                go.guiTexture.pixelInset.y,
													go.guiTexture.pixelInset.width,
													go.guiTexture.pixelInset.height);
				
				gt.transform.position = new Vector3(0, 
					                                go.transform.position.y,
					                                go.transform.position.z);
				

			}
		}
	}
	
	[MenuItem ("ENDI/GuiTexture/Convert transform.Position.y to pixelInset.y")]
	public static void ConvertTransformPositionYToPixelInsetY () 
	{
		foreach(GameObject go in Selection.gameObjects)
		{
			foreach(GUITexture gt in go.GetComponentsInChildren<GUITexture>())
			{
				gt.guiTexture.pixelInset = new Rect(go.guiTexture.pixelInset.x,
					                                go.transform.position.y * PlayerSettings.defaultScreenHeight,
													go.guiTexture.pixelInset.width,
													go.guiTexture.pixelInset.height);
				
				gt.transform.position = new Vector3(go.transform.position.x, 
					                                0,
					                                go.transform.position.z);
				

			}
		}
	}
}
