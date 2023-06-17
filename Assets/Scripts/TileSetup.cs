using System.Collections.Generic;
using UnityEngine;

public static class TileSetup
{
    [SerializeField]
    static List<Tile> potentialBuildingTiles = new();
    static List<List<Tile>> tempGroups = new();

    public static void InitialSetup()
    {
        Tile tile;
        int tempGroupsIndex=0;

        for (int x = 0; x < TileGrid.xWidth; x++)
        {
            for (int z = 0; z < TileGrid.zLength; z++)
            {
                tile = TileGrid.column[x].row[z];

                if (x%2 == 0 && z%2==0)
                {
                    tile.transform.Translate(new(0, 1));
                    tile.tileType = TileType.Building;
                    tile.tempGroup = tempGroupsIndex;
                    tempGroups.Add(new());
                    tempGroups[tempGroupsIndex].Add(tile);
                    tempGroupsIndex++;
                }

                if (x % 2 == 1 && z % 2 == 0)
                {
                    //tile.transform.Translate(new(0, -1));
                    tile.neighbours[0] = TileGrid.column[x - 1].row[z];
                    tile.neighbours[1] = TileGrid.column[x + 1].row[z];
                    potentialBuildingTiles.Add(tile);
                }

                if (x % 2 == 0 && z % 2 == 1)
                {
                    //tile.transform.Translate(new(0, -1));
                    tile.neighbours[0] = TileGrid.column[x].row[z - 1];
                    tile.neighbours[1] = TileGrid.column[x].row[z + 1];
                    potentialBuildingTiles.Add(tile);
                }
            }
        }
    }

    public static void BuildingTilesSetup()
    {
        while (potentialBuildingTiles.Count>0)
        {
            int potentialBuilding = Random.Range(0, potentialBuildingTiles.Count);
            Tile tile = potentialBuildingTiles[potentialBuilding];
            int group1 = tile.neighbours[0].tempGroup;
            int group2 = tile.neighbours[1].tempGroup;

            if (group1!=group2 && tempGroups[group1].Count < 3 && tempGroups[group2].Count < 3)
            {
                tile.transform.Translate(new(0, 1));
                tile.tileType = TileType.Building;

                while (tempGroups[group2].Count>0)
                {
                    tempGroups[group2][0].tempGroup = group1;
                    SupportFunctions.MoveBetweenLists(tempGroups[group2], tempGroups[group1], tempGroups[group2][0]);
                }
            }
            potentialBuildingTiles.RemoveAt(potentialBuilding);
        }
    }
}
public enum TileType
{
    Road, Building
}