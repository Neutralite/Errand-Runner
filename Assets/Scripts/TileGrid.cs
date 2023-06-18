using System;
using System.Collections.Generic;
using UnityEngine;

public static class TileGrid
{
    public static int xWidth, zLength;
    public static Column[] column;
    public static List<Tile> roadTiles = new(), buildingTiles = new();
    public static void CreateGrid(int x, int z)
    {
        xWidth = x;
        zLength = z;
        PrepareGrid();
        SpawnTiles();
        LinkTiles();
    }

    static void PrepareGrid()
    {
        if (xWidth % 2 == 0)
        {
            xWidth++;
        }
        if (zLength % 2 == 0)
        {
            zLength++;
        }
        column = new Column[xWidth];
        for (int i = 0; i < zLength; i++)
        {
            column[i].row = new Tile[zLength];
        }
    }

    static void SpawnTiles()
    {
        Vector3 position = new();
        for (int x = 0; x < xWidth; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                column[x].row[z] = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Tile).GetComponent<Tile>();
                position.x=x;
                position.z = z;
                column[x].row[z].transform.position = position;
                column[x].row[z].xCord = x;
                column[x].row[z].zCord = z;
                column[x].row[z].gameObject.SetActive(true);
            }
        }
    }

    static void LinkTiles()
    {
        Tile tile;
        for (int x = 0; x < xWidth; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                tile = column[x].row[z];
                if (z<zLength-1)
                {
                    tile.neighbourTiles[0] = column[x].row[z + 1];
                }
                if (x > 0)
                {
                    tile.neighbourTiles[1] = column[x - 1].row[z];
                }
                if (x<xWidth-1)
                {
                    tile.neighbourTiles[2] = column[x+1].row[z];
                }
                if (z>0)
                {
                    tile.neighbourTiles[3] = column[x].row[z-1];
                }

            }
        }
    }
}
[Serializable]
public struct Column
{
    public Tile[] row;
}
