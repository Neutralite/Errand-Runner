using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField]
    Text scoreText;
    int score = 0;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = $"${score}";
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