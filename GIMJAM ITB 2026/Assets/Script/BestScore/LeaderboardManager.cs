using UnityEngine;
using System.IO;

[System.Serializable]
public class LeaderboardData
{
    public float bestScore = 0f;
}

public class LeaderboardManager : MonoBehaviour
{

    public static LeaderboardManager instance;

    string filePath;
    public LeaderboardData leaderboardData;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        filePath = Application.persistentDataPath + "/leaderboard.json";
        LoadData();
    }

    public void AddScore(float newScore)
    {
        if (newScore > leaderboardData.bestScore)
        {
            leaderboardData.bestScore = newScore;
            SaveData();
        }
    }

    public float GetBestScore()
    {
        return leaderboardData.bestScore;
    }

    void LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            leaderboardData = JsonUtility.FromJson<LeaderboardData>(json);
        }
        else
        {
            leaderboardData = new LeaderboardData();
        }
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(leaderboardData, true);
        File.WriteAllText(filePath, json);
    }
}