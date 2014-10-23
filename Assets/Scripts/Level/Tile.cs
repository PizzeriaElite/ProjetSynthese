using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Tile
{
    public static List<Tile> all = new List<Tile>();
    public const float HALF_SIZE = 0.5f;
    
    public enum Type
    {
        Empty,
        Floor,
        Wall,
        Platform,
        Angle45Left,
        Angle45Right,
        Ladder,
        LadderTop,
        LadderBottom,
        Spawn,
        Exit,
        Movable
    }
    
    public TileParam param;
    public Type type;
    public Transform visual;
    
    public Tile(int x, int y, Tile.Type type)
    {
        this.param = new TileParam(x, y);
        this.type = type;
        all.Add(this);
    }

    public Tile(Tile.Type type)
    {
        this.type = type;
        all.Add(this);
    }
    
    public bool Walkable()
    {
        return false;
    }
    
    public bool Solid()
    {
        return type == Type.Floor ||
            type == Type.Wall ||
            type == Type.Angle45Left ||
            type == Type.Angle45Right;
    }
    
    public void Destroy()
    {
        all.Remove(this);
    }
}

public class TileParam
{
    public int x;
    public int y;

    public TileParam(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class ExitParam:TileParam
{
    public string pathNextLevel;

    public ExitParam(int x, int y, string pathNextLevel):base(x, y)
    {
        this.pathNextLevel = pathNextLevel;
    }
}

