using UnityEngine;

public class LoopingWalls : MonoBehaviour
{
    private void Awake()
    {
        TileGridManager.TileGridSetup += Setup;
    }

    void Setup()
    {
        Vector3 temp = new(TileGrid.Instance.xWidth,1,TileGrid.Instance.zLength);
        transform.position = (temp-Vector3.right-Vector3.forward) / 2;
        //transform.localScale = temp;
        TileGridManager.TileGridSetup -= Setup;
        Destroy(this);
    }
}
