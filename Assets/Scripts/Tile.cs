using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public int xCord, zCord, tempGroupIndex;
    public Tile[] neighbourTiles = new Tile[4]; //N,W,E,S
    public List<Tile> tempGroup;
}

