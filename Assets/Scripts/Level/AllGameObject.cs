using System;
using UnityEngine;

public class AllGameObject:MonoBehaviour
{
    [System.Serializable]
    public class BlocPrefabs
    {
        public GameObject collider;
        public GameObject Floor;
        public GameObject wall;
        public GameObject platform;
        public GameObject angleLeft45;
        public GameObject angleRight45;
        public GameObject ladder;
        public GameObject ladderTop;
        public GameObject ladderBottom;
        public GameObject player;
        public GameObject exit;
        public GameObject movable;
    }
    
    public BlocPrefabs blocPrefabs;
    private const int DEFAULT_MOVABLE_Y = -11;
    private const int DEFAULT_X = -10;
    private const int DEFAULT_Y = -10;
    private int indexCollider = 0;
    private GameObject[] AllCollider = new GameObject[100];
    private int indexFloor = 0;
    private GameObject[] AllFloor = new GameObject[200];
    private int indexWall = 0;
    private GameObject[] AllWall = new GameObject[400];
    private int indexPlatform = 0;
    private GameObject[] AllPlatform = new GameObject[100];
    private int indexAngleLeft45 = 0;
    private GameObject[] AllAngleLeft45 = new GameObject[100];
    private int indexAngleRight45 = 0;
    private GameObject[] AllAngleRight45 = new GameObject[100];
    private int indexLadder = 0;
    private GameObject[] AllLadder = new GameObject[100];
    private int indexLadderTop = 0;
    private GameObject[] AllLadderTop = new GameObject[50];
    private int indexLadderBottom = 0;
    private GameObject[] AllLadderBottom = new GameObject[50];
    private int indexPlayer = 0;
    private GameObject[] AllPlayer = new GameObject[1];
    private int indexExit = 0;
    private GameObject[] AllExit = new GameObject[1];
    private int indexMovable = 0;
    private GameObject[] AllMovable = new GameObject[50];

    public void Awake()
    {  
        for (int i = 0; i < AllCollider.Length; i++)
        {
            AllCollider [i] = (GameObject)Instantiate(blocPrefabs.collider, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllWall.Length; i++)
        {
            AllWall [i] = (GameObject)Instantiate(blocPrefabs.wall, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllFloor.Length; i++)
        {
            AllFloor [i] = (GameObject)Instantiate(blocPrefabs.Floor, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllAngleLeft45.Length; i++)
        {
            AllAngleLeft45 [i] = (GameObject)Instantiate(blocPrefabs.angleLeft45, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllAngleRight45.Length; i++)
        {
            AllAngleRight45 [i] = (GameObject)Instantiate(blocPrefabs.angleRight45, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllExit.Length; i++)
        {
            AllExit [i] = (GameObject)Instantiate(blocPrefabs.exit, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllLadder.Length; i++)
        {
            AllLadder [i] = (GameObject)Instantiate(blocPrefabs.ladder, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllLadderBottom.Length; i++)
        {
            AllLadderBottom [i] = (GameObject)Instantiate(blocPrefabs.ladderBottom, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllLadderTop.Length; i++)
        {
            AllLadderTop [i] = (GameObject)Instantiate(blocPrefabs.ladderTop, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllPlatform.Length; i++)
        {
            AllPlatform [i] = (GameObject)Instantiate(blocPrefabs.platform, new Vector3(DEFAULT_X, DEFAULT_Y), Quaternion.identity);
        }

        for (int i = 0; i < AllPlayer.Length; i++)
        {
            AllPlayer [i] = (GameObject)Instantiate(blocPrefabs.player, new Vector3(DEFAULT_X, DEFAULT_Y + 1), Quaternion.identity);
        }

        for (int i = 0; i < AllMovable.Length; i++)
        {
            AllMovable [i] = (GameObject)Instantiate(blocPrefabs.movable, new Vector3(DEFAULT_X + i, DEFAULT_MOVABLE_Y), Quaternion.identity);
        }

    }

    public GameObject GameObjectFromTileType(Tile.Type spaceType)
    {
        GameObject tile = null;

        switch (spaceType)
        {
            case Tile.Type.Floor:
                tile = AllFloor [indexFloor];
                indexFloor++;
                break;
            case Tile.Type.Wall:
                tile = AllWall [indexWall];
                indexWall++;
                break;
            case Tile.Type.Platform:
                tile = AllPlatform [indexPlatform];
                indexPlatform++;
                break;
            case Tile.Type.Angle45Left:
                tile = AllAngleLeft45 [indexAngleLeft45];
                indexAngleLeft45++;
                break;
            case Tile.Type.Angle45Right:
                tile = AllAngleRight45 [indexAngleRight45];
                indexAngleRight45++;
                break;
            case Tile.Type.Ladder:
                tile = AllLadder [indexLadder];
                indexLadder++;
                break;
            case Tile.Type.LadderBottom:
                tile = AllLadderBottom [indexLadderBottom];
                indexLadderBottom++;
                break;
            case Tile.Type.LadderTop:
                tile = AllLadderTop [indexLadderTop];
                indexLadderTop++;
                break;
            case Tile.Type.Spawn:
                tile = AllPlayer [indexPlayer];
                indexPlayer++;
                break;
            case Tile.Type.Exit:
                tile = AllExit [indexExit];
                indexExit++;
                break;
            case Tile.Type.Movable:
                tile = AllMovable [indexMovable];
                indexMovable++;
                break;
        }
        
        return tile;
    }

    public GameObject GetCollider()
    {
        GameObject tile = AllCollider [indexCollider];
        indexCollider++;
        return tile;
    }

    public void ResetAllGameObject()
    {
        for (int i = indexCollider - 1; i >= 0; i--)
        {
            AllCollider [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexCollider = 0;

        for (int i = indexFloor - 1; i >= 0; i--)
        {
            AllFloor [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexFloor = 0;
        
        for (int i = indexAngleLeft45 - 1; i >= 0; i--)
        {
            AllAngleLeft45 [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexAngleLeft45 = 0;
        
        for (int i = indexAngleRight45 - 1; i >= 0; i--)
        {
            AllAngleRight45 [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexAngleRight45 = 0;
        
        for (int i = indexExit - 1; i >= 0; i--)
        {
            AllExit [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexExit = 0;
        
        for (int i = indexLadder - 1; i >= 0; i--)
        {
            AllLadder [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexLadder = 0;
        
        for (int i = indexLadderBottom - 1; i >= 0; i--)
        {
            AllLadderBottom [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexLadderBottom = 0;
        
        for (int i = indexLadderTop - 1; i >= 0; i--)
        {
            AllLadderTop [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexLadderTop = 0;
        
        for (int i = indexPlatform - 1; i >= 0; i--)
        {
            AllPlatform [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexPlatform = 0;
        
        for (int i = indexPlayer - 1; i >= 0; i--)
        {
            AllPlayer [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y + 1, 0);
        }
        indexPlayer = 0;

        for (int i = indexWall - 1; i >= 0; i--)
        {
            AllWall [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexWall = 0;

        for (int i = indexMovable - 1; i >= 0; i--)
        {
            AllMovable [i].transform.position = new Vector3(DEFAULT_X, DEFAULT_Y, 0);
        }
        indexMovable = 0;

    }
}


