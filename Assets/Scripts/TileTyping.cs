using System.Collections.Generic;
using UnityEngine;

public class TileTyping: ISetupStep
{
    List<Tile> potentialBuildingTiles = new();
    List<List<Tile>> tempGroups = new();
    Tile tempTile;

    public void RunStep()
    {
        InitialTyping();
        RetypeToBuilding();
    }
    void InitialTyping()
    {
        int tempGroupsIndex=0;

        for (int x = 0; x < TileGrid.Instance.xWidth; x++)
        {
            for (int z = 0; z < TileGrid.Instance.zLength; z++)
            {
                tempTile = TileGrid.Instance.column[x].row[z];

                if (x%2 == 0 && z%2==0) // tile is a building tile
                {
                    //tempTile.transform.Translate(new(0, 1));
                    tempTile.tileType = TileType.Building;
                    tempTile.tempGroupIndex = tempGroupsIndex;
                    tempGroups.Add(new());
                    tempGroups[tempGroupsIndex].Add(tempTile);
                    tempGroupsIndex++;

                    TileGrid.Instance.buildingTiles.Add(tempTile);
                    continue;
                }
                else 
                {
                    TileGrid.Instance.roadTiles.Add(tempTile);
                }
                
                if (x % 2 == 0 && z % 2 == 1)
                {
                    //tile.transform.Translate(new(0, -1));
                    tempTile.tempGroup.Add(tempTile.neighbourTiles[0]);
                    tempTile.tempGroup.Add(tempTile.neighbourTiles[3]);
                    potentialBuildingTiles.Add(tempTile);
                    continue;
                }

                if (x % 2 == 1 && z % 2 == 0) 
                {
                    //tile.transform.Translate(new(0, -1));
                    tempTile.tempGroup.Add(tempTile.neighbourTiles[1]);
                    tempTile.tempGroup.Add(tempTile.neighbourTiles[2]);
                    potentialBuildingTiles.Add(tempTile);
                    continue;
                }
            }
        }
    }

    void RetypeToBuilding()
    {
        int potentialBuilding;
        int group1, group2;
        while (potentialBuildingTiles.Count>0)
        {
            potentialBuilding = Random.Range(0, potentialBuildingTiles.Count);
            tempTile = potentialBuildingTiles[potentialBuilding];
            group1 = tempTile.tempGroup[0].tempGroupIndex;
            group2 = tempTile.tempGroup[1].tempGroupIndex;

            if (group1!=group2 && tempGroups[group1].Count < 4 && tempGroups[group2].Count < 3)
            {
                //tempTile.transform.Translate(new(0, 1));
                tempTile.tileType = TileType.Building;
                tempTile.tempGroupIndex = group1;
                tempGroups[group1].Add(tempTile);
                SupportFunctions.MoveBetweenLists(TileGrid.Instance.roadTiles, TileGrid.Instance.buildingTiles,tempTile);

                while (tempGroups[group2].Count>0)
                {
                    tempGroups[group2][0].tempGroupIndex = group1;
                    SupportFunctions.MoveBetweenLists(tempGroups[group2], tempGroups[group1], tempGroups[group2][0]);
                }
            }
            tempTile.tempGroup = null;
            potentialBuildingTiles.Remove(tempTile);
        }
        tempGroups = null;
    }
}
