using UnityEngine;

public class BuildingPlacement:ISetupStep
{    
    GameObject tempBuilding;
    bool n, w, e, s;
    Vector3 position = new();
    public void RunStep()
    {
        foreach (Tile tempTile in TileGrid.Instance.buildingTiles)
        {
            PlaceHouses(tempTile);
        }
    }
    
    void PlaceHouses(Tile tempTile)
    {
        n = tempTile.neighbourTiles[0] == null || tempTile.neighbourTiles[0].tileType == TileType.Building;
        w = tempTile.neighbourTiles[1] == null || tempTile.neighbourTiles[1].tileType == TileType.Building;
        e = tempTile.neighbourTiles[2] == null || tempTile.neighbourTiles[2].tileType == TileType.Building;
        s = tempTile.neighbourTiles[3] == null || tempTile.neighbourTiles[3].tileType == TileType.Building;

        for (int i = 0; i < 4; i++)
        {
            position.x = tempTile.xCord + (i % 2 == 0 ? -0.25f : 0.25f);
            position.z = tempTile.zCord + (i < 2 ? 0.25f : -0.25f);

            if ((n && ((w && i == 0) || (e && i == 1))) || (s && ((w && i == 2) || (e && i == 3))))
            {
                tempBuilding = ObjectPoolManager.Instance.ReleaseObject(ObjectID.EmptyPatch);
                goto end;
            }
            tempBuilding = ObjectPoolManager.Instance.ReleaseObject(ObjectID.House);

            if (!s && i > 1)
            {
                goto end;
            }
            tempBuilding.transform.Rotate(0, i % 2 == 0 ? 90 : -90, 0);
            if (!n && i < 2)
            {
                tempBuilding.transform.Rotate(0, i % 2 == 0 ? 90 : -90, 0);
            }

        end:
            tempBuilding.transform.position = position;
            tempBuilding.SetActive(true);
        }
    }
}
