using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    [SerializeField]
    Text scoreText;
    int health = 100;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            health = Mathf.Max(health, 0);
            scoreText.text = $"Health: {health}";
        }
    }
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
}
