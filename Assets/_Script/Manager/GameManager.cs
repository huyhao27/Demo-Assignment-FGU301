using TMPro; // Thêm thư viện này để dùng TextMeshPro
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private int currentScore;
    private int highScore;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        UpdateUI();
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            Debug.Log("New HighScore saved: " + highScore);
        }
        
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore;
        highScoreText.text = "High Score: " + highScore;
    }
}