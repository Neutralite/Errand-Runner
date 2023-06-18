using UnityEngine;

public class RoadTexturing : MonoBehaviour,ISetupStep
{
    public static RoadTexturing Instance { get; private set; }

    public Texture[] roadTextures;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RunStep()
    {
        TextureRoads();
    }

    public void TextureRoads()
    {
        bool n,w,e,s;
        foreach (Tile tempTile in TileGrid.roadTiles)
        {
            if (tempTile.xCord == 0 || tempTile.xCord == TileGrid.xWidth-1)
            {
                tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[8];
                continue;
            }
            if (tempTile.zCord == 0 || tempTile.zCord == TileGrid.zLength - 1)
            {
                tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[6];
                continue;
            }

            n = tempTile.neighbourTiles[0].tileType == TileType.Road;
            w = tempTile.neighbourTiles[1].tileType == TileType.Road;
            e = tempTile.neighbourTiles[2].tileType == TileType.Road;
            s = tempTile.neighbourTiles[3].tileType == TileType.Road;

            if (n)
            {
                if (w)
                {
                    tempTile.GetComponentInChildren<Renderer>().material.mainTexture = e ? (s ? roadTextures[0] : roadTextures[1]) : (s ? roadTextures[2] : roadTextures[3]);
                }
                else
                {
                    tempTile.GetComponentInChildren<Renderer>().material.mainTexture = e ? (s ? roadTextures[4] : roadTextures[5]) : roadTextures[6];
                }
                continue;
            }
            if (w)
            {
                tempTile.GetComponentInChildren<Renderer>().material.mainTexture = e ? (s ? roadTextures[7] : roadTextures[8]) : roadTextures[9];
                continue;
            }
            tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[10];

        }

        Destroy(this);
    }
}
