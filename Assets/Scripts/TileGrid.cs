using System;
using UnityEngine;

public static class TileGrid
{
    public static int xWidth, zLength;
    public static Column[] column;

    public static void CreateGrid(int x, int z)
    {
        xWidth = x;
        zLength = z;
        PrepareGrid();
        SpawnTiles();
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
        Vector3 position;
        for (int x = 0; x < xWidth; x++)
        {
            for (int z = 0; z < zLength; z++)
            {
                position = new(x,0,z);
                column[x].row[z] = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Tile).GetComponent<Tile>();
                column[x].row[z].transform.position = position;
                column[x].row[z].xCord = x;
                column[x].row[z].zCord = z;
                column[x].row[z].gameObject.SetActive(true);
            }
        }
    }
}
[Serializable]
public struct Column
{
    public Tile[] row;
}
