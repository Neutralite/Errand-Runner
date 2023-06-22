using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsolatedManager : MonoBehaviour
{
    public static IsolatedManager Instance { get; private set; }
    [SerializeField]
    int enemySpawnLimit;
    public List<IsolatedAI> isolatedAIs;
    IsolatedAI tempIsolated;
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

    public void SpawnIsolated()
    {
        if (isolatedAIs.Count < enemySpawnLimit)
        {
            tempIsolated = ObjectPoolManager.Instance.ReleaseObject(ObjectID.Isolated).GetComponent<IsolatedAI>();
            isolatedAIs.Add(tempIsolated);
            tempIsolated.transform.position = TileGrid.Instance.roadTiles[Random.Range(0, TileGrid.Instance.roadTiles.Count)].transform.position;
            tempIsolated.destination = tempIsolated.transform.position;

            tempIsolated.gameObject.SetActive(true);
        }
    }
}
