using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10*Time.unscaledDeltaTime, 0);
        if (GameStateManager.Instance.gameState!=GameState.MainMenu)
        {
            Destroy(this);
        }
    }
}
