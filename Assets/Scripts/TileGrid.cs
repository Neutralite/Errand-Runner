using System.Collections.Generic;
using UnityEngine;

public class TileGrid
{
    public static TileGrid Instance { get; private set; }
    public int xWidth, zLength;
    public Column[] column;
    public List<Tile> roadTiles = new(), buildingTiles = new();

    public TileGrid(int x, int z)
    {
        Instance = null;
        Instance = this;

        xWidth = x % 2 == 0? x+1:x;
        zLength = z % 2 == 0? z+1:z;
    }

    ~TileGrid()
    {
        Debug.Log("World Destroyed");
    }
}
public struct Column
{
    public Tile[] row;
}

public enum TileType
{
    Road, Building
}