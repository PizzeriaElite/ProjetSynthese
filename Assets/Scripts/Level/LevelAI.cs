using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//todo : clean this (inheritate from level?)
public class LevelAI : MonoBehaviour 
{
	public List<Platform> platforms = new List<Platform>();
	
	[System.Serializable]
	public class Platform
	{
		public Vector3 start;
		public Vector3 end;
	}
	
	private void RefreshPlatforms()
	{

	}

	#region Debug
	private void OnDrawGizmos()
	{
		DrawPlaforms();
	}
	
	private void DrawPlaforms()
	{
		Gizmos.color = Color.black;
		
		foreach(Platform platform in platforms)
		{
			Vector3 start = new Vector3(platform.start.x - Tile.HALF_SIZE, platform.start.y, -Tile.HALF_SIZE);
			Vector3 end   = new Vector3(platform.end.x   + Tile.HALF_SIZE, platform.end.y  , -Tile.HALF_SIZE);
			
			Gizmos.DrawSphere(start, .1f);
			Gizmos.DrawSphere(end, .1f);
			Gizmos.DrawLine(start, end);
		}
	}
	#endregion
	
	private void OnLevelLoad()
	{
		RefreshPlatforms();
	}
	
	private	void OnEnable()
	{
		LevelLoader.onLevelLoad += OnLevelLoad;
	}
	
	private void OnDisable()
	{
		LevelLoader.onLevelLoad -= OnLevelLoad;
	}
}
