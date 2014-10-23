using UnityEngine;
using System;

public class Level : MonoBehaviour
{
    public AllGameObject AllGameObject;
	public int width;
    public int height;
    [System.NonSerialized] 
    public Tile[,]
        tiles;

    public void Awake()
    {
        LevelLoader.onLevelLoad += OnLevelLoad;
    }

    public void OnLevelLoad(System.Object sender, EventArgs args)
    {
        AllGameObject.ResetAllGameObject();
        this.tiles = (Tile[,])sender;
        this.width = this.tiles.GetLength(0);
        this.height = this.tiles.GetLength(1);  
        CreateCollider();
        LoadSpaceVisuals();
    }

    public void LoadSpaceVisuals()
    {
        foreach (Tile tile in this.tiles)
        {
            LoadSpaceVisual(tile);
        }
    }

    private void LoadSpaceVisual(Tile tile)
    {
        GameObject objectTile = AllGameObject.GameObjectFromTileType(tile.type);
        if (objectTile != null)
        {
            objectTile.transform.position = new Vector3(tile.param.x, tile.param.y, 0);

            if (tile.type != Tile.Type.Spawn)
            {                               
                Param param = objectTile.GetComponent<Param>();
                param.tile = tile;
                tile.visual = objectTile.transform;
            }   

            Rigidbody body = objectTile.rigidbody;

            if (body != null)
            {
                body.useGravity = true;
            }
        }

    }

    private void CreateCollider()
    {
        CreateColliderHorizontal();
        CreateColliderVertical();
    }

    private void CreateColliderHorizontal()
    {
        float heightCollider = 1;
        float posXFloor = 0;
        float posYFloor = 0;
        float widthFloor = 0;
        float posXRoof = 0;
        float posYRoof = 0;
        float widthRoof = 0;

        Tile tile;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                tile = tiles [x, y];

                if (tile.type == Tile.Type.Floor)
                {
                    if (widthFloor == 0)
                    {
                        posXFloor = tile.param.x;
                        posYFloor = tile.param.y;
                    }
                    widthFloor++;
                    
                }
                else
                {
                    PlaceCollider(ref widthFloor, ref heightCollider, ref posXFloor, ref posYFloor);
                }

                if (y != 0)
                {
                    if (tile.type == Tile.Type.Wall && tiles [x, y - 1].type != Tile.Type.Wall)
                    {
                        if (widthRoof == 0)
                        {
                            posXRoof = tile.param.x;
                            posYRoof = tile.param.y;
                        }
                        widthRoof++;
                    }
                    else
                    {
                        PlaceCollider(ref widthFloor,  ref heightCollider, ref posXFloor, ref posYFloor);
                    }
                }               
            }
        }
    }

    private void PlaceCollider(ref float widthCollider, ref float heightCollider, ref float posXCollider, ref float posYCollider)
    {
        if (widthCollider != 0)
        {
            GameObject collider = AllGameObject.GetCollider();
            collider.transform.localScale = new Vector3(widthCollider, heightCollider, 1);
            collider.transform.position = new Vector3(CalculatePosXCollider(widthCollider, posXCollider), posYCollider, 0);
            posXCollider = 0;
            posYCollider = 0;
            widthCollider = 0; 
        }
    }
    
    private float CalculatePosXCollider(float widthCollider, float posXCollider)
    {
        if (widthCollider == 1)
        {
            return posXCollider;
        }
        return ((widthCollider - 1) / 2) + posXCollider;     
    }

    private void CreateColliderVertical()
    {
        float widthCollider = 1;
            float posX = 0;
        float posY = 0;
        float heightCollider = 0;

        
        Tile tile;
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tile = tiles [x, y];

                if (tile.type == Tile.Type.Wall && ((x > 0 && IsNotWallFloor(tiles [x - 1, y])) || ((x < width - 1 && IsNotWallFloor(tiles [x + 1, y])))))
                {
                    if (heightCollider == 0)
                    {
                        posX = tile.param.x;
                        posY = tile.param.y;
                    }
                    heightCollider++;
                    
                }
                else
                {
                    if (heightCollider == 1)
                    {
                        posX = 0;
                        posY = 0;
                        heightCollider = 0;
                    }
                    else if (heightCollider > 1)
                    {
                        PlaceCollider(ref widthCollider, ref heightCollider, ref posX, ref posY);
                    }
                }
            }


        }
    }

    private bool IsNotWallFloor(Tile tile)
    {
        return tile.type != Tile.Type.Wall && tile.type != Tile.Type.Floor;
    }

    public bool TileOverEmpty(Tile tile)
    {
        return tile.param.y < height - 1 && 
            (tiles [tile.param.x, tile.param.y + 1].type == Tile.Type.Empty ||
            tiles [tile.param.x, tile.param.y + 1].type == Tile.Type.Platform ||
            tiles [tile.param.x, tile.param.y + 1].type == Tile.Type.Ladder);
    }
    
    private void OnDestroy()
    {
        Tile.all = null;
    }
}
        