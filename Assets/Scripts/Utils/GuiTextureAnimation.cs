using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuiTextureAnimation : MonoBehaviour 
{
	public List<Texture2D> textures = new List<Texture2D>();  
    public float framesPerSecond = 30.0f;
    
	public string ressourcePath = "Piston/piston00";
	public WrapMode wrapMode = WrapMode.Once;
	public bool randomizeStartFrame = false;
	public bool playAutomatically = true;
	
	private float randomization = 0;
	private bool isPlaying = true;
	
	
    void Start()
	{
		if (randomizeStartFrame)
		{
     		randomization = Random.Range(0f, 999f);
		}
		
		if (ressourcePath.Length > 0)
		{
			for (int i = 1; i <= 30; i++)
			{
				string imageName = ressourcePath + (i < 10 ? "0" : "") + i.ToString();			
				textures.Add(Resources.Load(imageName, typeof(Texture2D)) as Texture2D);
			}
		}
		
		if (wrapMode == WrapMode.PingPong)
		{
			int textureCount = textures.Count;
			for (int i = 0; i < textureCount - 1; i++)
			{
				textures.Add(textures[textureCount - i - 2]);
			}
		}
		
		if (playAutomatically)
		{
			play();
		}
    }
	
	public void play()
	{
		if (textures.Count == 0)
		{
			Debug.LogWarning("Nothing to play");
		}
		else
		{
			isPlaying = true;
		}
	}
	
	public void stop()
	{
		if (isPlaying)
		{
			isPlaying = false;
		}
	}
	
    void Update () 
	{		
		if (isPlaying)
		{
	        int i = (int)((Time.time + randomization) * framesPerSecond);
			
			if (i == textures.Count)
			{
				if (wrapMode == WrapMode.Once || wrapMode == WrapMode.Clamp)
				{
					isPlaying = false;
					guiTexture.texture = textures[0];
					return;
				}
				
				if (wrapMode == WrapMode.ClampForever)
				{
					isPlaying = false;
				}
			}
			
	        i = i % textures.Count;
			
			guiTexture.texture = textures[i];
		}
	}
}
