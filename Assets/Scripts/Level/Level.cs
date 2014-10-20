using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Tile
{
	public static List<Tile> all = new List<Tile>();

	public const float HALF_SIZE = 0.5f;
	
	public enum Type {Empty, Ground, Wall, Platform, Angle45Left, Angle45Right, Ladder};
	
	public int x;
	public int y;
	
	public Type type;
	public Transform visual;
	
	public Tile()
	{
		all.Add(this);
	}
	
	public bool Walkable()
	{
		return false;
	}
	
	public bool Solid()
	{
		return type == Type.Ground ||
			   type == Type.Wall ||
			   type == Type.Angle45Left ||
			   type == Type.Angle45Right;
	}
	
	public void Destroy()
	{
		all.Remove(this);
	}
}

public class Level : MonoBehaviour 
{
	[System.Serializable]
	public class BlocPrefabs
	{
		public GameObject ground;
		public GameObject wall;
		public GameObject platform;
		public GameObject angle45Left;
		public GameObject angle45Right;
		public GameObject ladder;
	}
	
	public BlocPrefabs blocPrefabs;

	private int width;
	private int height;

	[System.NonSerialized] public Tile[,] tiles;

	public void Initialize(int newWidth, int newHeight)
	{

	}

	public void SetSpaceAt(int x, int y, Tile.Type tileType)
	{

	}

	public void LoadSpaceVisuals()
	{

	}

	private void ConvertWallSpaceToGroundSpaceIfNeeded(Tile space)
	{

	}

	private void LoadSpaceVisual(Tile tile)
	{

	}

	public bool TileOverEmpty(Tile tile)
	{
		return tile.y < height - 1 && 
		       (tiles[tile.x, tile.y + 1].type == Tile.Type.Empty ||
			    tiles[tile.x, tile.y + 1].type == Tile.Type.Platform ||
			    tiles[tile.x, tile.y + 1].type == Tile.Type.Ladder);
	}

	private GameObject PrefabFromTileType(Tile.Type spaceType)
	{
		switch(spaceType)
		{
			case Tile.Type.Empty       : return null;
			case Tile.Type.Ground      : return blocPrefabs.ground;
			case Tile.Type.Wall        : return blocPrefabs.wall;
			case Tile.Type.Platform    : return blocPrefabs.platform;
			case Tile.Type.Angle45Left : return blocPrefabs.angle45Left;
			case Tile.Type.Angle45Right: return blocPrefabs.angle45Right;
			case Tile.Type.Ladder      : return blocPrefabs.ladder;
		}

		return null;
	}
	
	private void OnDestroy()
	{
		Tile.all = null;
	}
}
		