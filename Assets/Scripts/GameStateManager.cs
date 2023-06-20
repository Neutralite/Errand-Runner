using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    public GameState gameState;
    [SerializeField] GameObject menu;

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
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && gameState != GameState.MainMenu)
        {
            Pause();
        }
    }

    public void Pause()
    {
        gameState = gameState == GameState.Playing ? GameState.Paused : GameState.Playing;
        Time.timeScale = gameState == GameState.Playing ? 1 : 0;
        Cursor.lockState = gameState == GameState.Playing ? CursorLockMode.Locked : CursorLockMode.None;
        menu.SetActive(gameState != GameState.Playing);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
[SerializeField]
public enum GameState
{
    MainMenu, Paused, Playing
}