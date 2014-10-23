using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelAI : MonoBehaviour 
{
	public List<Platform> platforms = new List<Platform>();
	public Level linkedLevel;

	[System.Serializable]
	public class Platform
	{
		public Vector3 start;
		public Vector3 end;
	}

	private void RefreshPlatforms()
	{
		this.platforms.Clear();
		for (int line = 0; line < this.linkedLevel.height; line++)
		{
			for (int column = 0; column < this.linkedLevel.width; column++)
			{
				if (this.linkedLevel.tiles[column, line].type == Tile.Type.Floor && line > 0)
				{
					if(this.linkedLevel.tiles[column, (line + 1)].type != Tile.Type.Floor)
					{
						Platform newPlatform = new Platform();
						newPlatform.start = new Vector3 (column, (line), 0);

						while(column < (this.linkedLevel.width -1) && this.linkedLevel.tiles[column + 1, line].type == Tile.Type.Floor
						      && this.linkedLevel.tiles[column + 1, line + 1].type != Tile.Type.Floor)
						{
							column++;
						}

						newPlatform.end = new Vector3 (column, line, 0);
						platforms.Add(newPlatform);
						Debug.Log("New platform from : (" + newPlatform.start.ToString() + ") to : (" + newPlatform.end.ToString() + ")");
					}
				}
			}
		}
	}

	#region Debug
	private void OnDrawGizmos()
	{
		DrawPlaforms();
	}
	
	private void DrawPlaforms()
	{
		Gizmos.color = Color.red;
		
		foreach(Platform platform in platforms)
		{
			Vector3 start = new Vector3(platform.start.x - Tile.HALF_SIZE, platform.start.y + 2*Tile.HALF_SIZE, -Tile.HALF_SIZE);
			Vector3 end   = new Vector3(platform.end.x   + Tile.HALF_SIZE, platform.end.y + 2*Tile.HALF_SIZE , -Tile.HALF_SIZE);
			
			Gizmos.DrawSphere(start, .1f);
			Gizmos.DrawSphere(end, .1f);
			Gizmos.DrawLine(start, end);
		}
	}
	#endregion
	
	private void OnLevelLoad(System.Object sender, System.EventArgs args)
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
