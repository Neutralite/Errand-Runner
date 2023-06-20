using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

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
}

