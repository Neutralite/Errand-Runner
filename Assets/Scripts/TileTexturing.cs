using UnityEngine;

public class TileTexturing : MonoBehaviour,ISetupStep
{
    public static TileTexturing Instance { get; private set; }
    public Texture[] roadTextures;
    bool n, w, e, s;

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
        foreach (Tile tempTile in TileGrid.Instance.roadTiles)
        {
            TextureRoad(tempTile);
        }
        Destroy(this);
    }

    void TextureRoad(Tile tempTile)
    {
        tempTile.gameObject.SetActive(true);

        if (tempTile.xCord == 0 || tempTile.xCord == TileGrid.Instance.xWidth - 1)
        {
            tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[8];
            return;
        }
        if (tempTile.zCord == 0 || tempTile.zCord == TileGrid.Instance.zLength - 1)
        {
            tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[6];
            return;
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
            return;
        }
        if (w)
        {
            tempTile.GetComponentInChildren<Renderer>().material.mainTexture = e ? (s ? roadTextures[7] : roadTextures[8]) : roadTextures[9];
            return;
        }
        tempTile.GetComponentInChildren<Renderer>().material.mainTexture = roadTextures[10];
    }
}
