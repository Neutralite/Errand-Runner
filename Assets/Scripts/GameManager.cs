using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    float enemySpawnDelay,spawnTimer;
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
        TileGridManager.Instance.Setup();

        Player.Instance.controller.enabled = false;
        Player.Instance.transform.position = TileGrid.Instance.roadTiles[Random.Range(0, TileGrid.Instance.roadTiles.Count)].transform.position;
        Player.Instance.transform.Translate(0f,0.05f,0);
        Player.Instance.controller.enabled = true;

        QuestManager.Instance.SpawnQuest();
    }

    private void Update()
    {
        if (GameStateManager.Instance.gameState == GameState.Playing)
        {
            if (DayNightCycle.Instance.timeofDay == TimeofDay.Day)
            {
                spawnTimer += Time.deltaTime;
                if (spawnTimer > enemySpawnDelay)
                {
                    IsolatedManager.Instance.SpawnIsolated();
                    spawnTimer = 0;
                }
            }

            if (HealthManager.Instance.Health == 0 || ScoreManager.Instance.Score == 20)
            {
                GameStateManager.Instance.Restart();
            }
        }
    }
}

