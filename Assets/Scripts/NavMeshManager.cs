using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshManager : MonoBehaviour
{
    public NavMeshSurface surface;
    private void Awake()
    {
        TileGridManager.TileGridSetup += Setup;
    }

    void Setup()
    {
        surface.BuildNavMesh();
        TileGridManager.TileGridSetup -= Setup;
    }
}