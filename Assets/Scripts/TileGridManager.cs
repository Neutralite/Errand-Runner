using System;
using UnityEngine;

public class TileGridManager : MonoBehaviour
{
    public static TileGridManager Instance { get; private set; }

    [SerializeField] int xWidth, zLength;
    public TileGrid tileGrid;

    public static event Action TileGridSetup;

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

    public void Setup()
    {
        tileGrid = new(xWidth, zLength);
        ISetupStep currentStep = new SpawnGrid();
        currentStep.RunStep();
        currentStep = new TileTyping();
        currentStep.RunStep();
        currentStep = TileTexturing.Instance;
        currentStep.RunStep();
        currentStep = new BuildingPlacement();
        currentStep.RunStep();
        TileGridSetup?.Invoke();
    }
}
