using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

public class LevelLoader: MonoBehaviour
{
    public static event EventHandler onLevelLoad;

    void Start()
    {
		LoadLevel(Resources.Load<TextAsset>("Levels/LevelTestPlatformsFinal"));
    }

    public static void LoadNextLevel(string nextLevel)
    {
        string path = "Levels/" + nextLevel;
        LoadLevel(Resources.Load<TextAsset>(path));
    }
    
    private static void LoadLevel(TextAsset levelFile)
    {
        Tile[,] tiles;
        try
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(levelFile.text);

            XmlNode map = doc.SelectSingleNode("/Map");
            int width = Convert.ToInt32(map.Attributes.GetNamedItem("Width").Value);
            int height = Convert.ToInt32(map.Attributes.GetNamedItem("Height").Value);

            tiles = new Tile[width, height];

            XmlNodeList nodeTiles = doc.SelectNodes("/Map/Tile");

            int x = 0;
            int y = height - 1;
            foreach (XmlNode node in nodeTiles)
            {
                string typeTile = node.Attributes.GetNamedItem("Type").Value;

                switch (typeTile)
                {
                    case "Empty":
                        tiles [x, y] = new Tile(x, y, Tile.Type.Empty);
                        break;
                    case "Wall":
                        AddWall(node, x, y, tiles);
                        break;
                    case "Spawn":
                        tiles [x, y] = new Tile(x, y, Tile.Type.Spawn);
                        break;
                    case "Movable":
                        tiles [x, y] = new Tile(x, y, Tile.Type.Movable);
                        break;
                    case "Exit":
                        AddExit(node, x, y, tiles);
                        break;
                    case "Ladder":
                        AddLadder(node, x, y, tiles);
                        break;
                    default:
                        tiles [x, y] = new Tile(x, y, Tile.Type.Empty);
                        break;
                }
                
                y--;
                if (y < 0)
                {
                    y = height - 1;
                    x++;
                }
            }
            onLevelLoad(tiles, new EventArgs());

        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }               
    }

    private static void AddWall(XmlNode node, int x, int y, Tile[,] tiles)
    {
        string type = node.FirstChild.Attributes.GetNamedItem("Type").Value;

        switch (type)
        {
            case "Floor":
                tiles [x, y] = new Tile(x, y, Tile.Type.Floor);
                break;
            case "Wall":
                tiles [x, y] = new Tile(x, y, Tile.Type.Wall);
                break;
            case "AngleLeft45":
                tiles [x, y] = new Tile(x, y, Tile.Type.Angle45Left);
                break;
            case "AngleRight45":
                tiles [x, y] = new Tile(x, y, Tile.Type.Angle45Right);
                break;
            case "Platform":
                tiles [x, y] = new Tile(x, y, Tile.Type.Platform);
                break;
        }
    }

    private static void AddLadder(XmlNode node, int x, int y, Tile[,] tiles)
    {
        string type = node.FirstChild.Attributes.GetNamedItem("Type").Value;
        
        switch (type)
        {
            case "Middle":
                tiles [x, y] = new Tile(x, y, Tile.Type.Ladder);
                break;
            case "Bottom":
                tiles [x, y] = new Tile(x, y, Tile.Type.LadderBottom);
                break;
            case "Top":
                tiles [x, y] = new Tile(x, y, Tile.Type.LadderTop);
                break;

        }
    }

    private static void AddExit(XmlNode node, int x, int y, Tile[,] tiles)
    {
        string pathNextLevel = node.FirstChild.Attributes.Item(0).Value;

        Tile tile = new Tile(Tile.Type.Exit);
        tile.param = new ExitParam(x, y, pathNextLevel);
        tiles [x, y] = tile;
    }    
}
