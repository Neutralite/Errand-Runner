using UnityEngine;

public class MainMenuMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed*Time.unscaledDeltaTime, 0);
        if (GameStateManager.Instance.gameState!=GameState.MainMenu)
        {
            Destroy(this);
        }
    }
}
