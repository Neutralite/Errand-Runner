using UnityEngine;

public class CommunityManager : MonoBehaviour
{
    public static CommunityManager Instance { get; private set; }
    public int xWidth, zLength;

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

    // Start is called before the first frame update
    void Start()
    {
        TileGrid.CreateGrid(xWidth,zLength);
        TileSetup.InitialSetup();
        TileSetup.BuildingTilesSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
