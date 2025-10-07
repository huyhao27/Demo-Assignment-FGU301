using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
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
    
    //Demo File I/O & Serialization 
    [Header("Game Data")]
    [SerializeField] private PlayerController player;
    
    public void SaveGame()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/player.dat";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Game saved to " + path);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/player.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            Vector3 loadedPosition = new Vector3(data.position[0], data.position[1], data.position[2]);
            player.transform.position = loadedPosition;

            Debug.Log("Game loaded!");
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}