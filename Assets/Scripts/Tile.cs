using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileType tileType;
    public int xCord, zCord, tempGroup;
    public Tile[] neighbours = new Tile[2];
}
