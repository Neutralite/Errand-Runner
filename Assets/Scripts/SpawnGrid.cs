using UnityEngine;

public class SpawnGrid:ISetupStep
{
    public void RunStep()
    {
        PrepareGrid();
        SpawnTiles();
        LinkTiles();
    }

    void PrepareGrid()
    {
        TileGrid.Instance.column = new Column[TileGrid.Instance.xWidth];
        for (int i = 0; i < TileGrid.Instance.xWidth; i++)
        {
            TileGrid.Instance.column[i].row = new Tile[TileGrid.Instance.zLength];
        }
    }

    void SpawnTiles()
    {
        Vector3 position = new();
        for (int x = 0; x < TileGrid.Instance.xWidth; x++)
        {
            for (int z = 0; z < TileGrid.Instance.zLength; z++)
            {
                TileGrid.Instance.column[x].row[z] = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Tile).GetComponent<Tile>();
                position.x=x;
                position.z = z;
                TileGrid.Instance.column[x].row[z].transform.position = position;
                TileGrid.Instance.column[x].row[z].xCord = x;
                TileGrid.Instance.column[x].row[z].zCord = z;
            }
        }
    }

    void LinkTiles()
    {
        Tile tile;
        for (int x = 0; x < TileGrid.Instance.xWidth; x++)
        {
            for (int z = 0; z < TileGrid.Instance.zLength; z++)
            {
                tile = TileGrid.Instance.column[x].row[z];
                if (z< TileGrid.Instance.zLength -1)
                {
                    tile.neighbourTiles[0] = TileGrid.Instance.column[x].row[z + 1];
                }
                if (x > 0)
                {
                    tile.neighbourTiles[1] = TileGrid.Instance.column[x - 1].row[z];
                }
                if (x< TileGrid.Instance.xWidth -1)
                {
                    tile.neighbourTiles[2] = TileGrid.Instance.column[x+1].row[z];
                }
                if (z>0)
                {
                    tile.neighbourTiles[3] = TileGrid.Instance.column[x].row[z-1];
                }

            }
        }
    }
}

