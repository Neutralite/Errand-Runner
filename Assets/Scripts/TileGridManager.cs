using System.Collections.Generic;
using UnityEngine;

public class TileGridManager : MonoBehaviour
{
    public static TileGridManager Instance { get; private set; }
    public int xWidth, zLength;
    public TileGrid tileGrid;
    [SerializeField]
    GameObject player;
    public List<QuestPoint> questPoints = new();

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
        tileGrid = new(xWidth,zLength);
        ISetupStep currentStep = new SpawnGrid();
        currentStep.RunStep();
        currentStep = new TileTyping();
        currentStep.RunStep();
        currentStep = TileTexturing.Instance;
        currentStep.RunStep();
        currentStep = new BuildingPlacement();
        currentStep.RunStep();

        player.transform.position = tileGrid.roadTiles[Random.Range(0, tileGrid.roadTiles.Count)].transform.position;
        player.transform.Translate(0, 0.05f, 0);


    }

    private void Update()
    {

    }
}
