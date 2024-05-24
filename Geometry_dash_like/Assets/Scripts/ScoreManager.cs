using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager
{
    private readonly ScoreEntry _scoreData;
    private const string FileName = "score.json";
    
    public ScoreManager(string playerName, string score, string levelIndex)
    {
        _scoreData = new ScoreEntry
        {
            playerName = VerifyPlayerName(playerName),
            score = score,
            levelIndex = levelIndex
        };
    }
    
    public void SaveScoreToJson()
    {
        var dataList = LoadScoreFromJson();
        
        dataList.scoreEntryList.Add(_scoreData);
        
        var json = JsonUtility.ToJson(dataList, true);
        var path = Path.Combine(Application.persistentDataPath, FileName);
        File.WriteAllText(path, json);

        Debug.Log("Data saved to: " + path);
    }
    
    private static ScoreEntryList LoadScoreFromJson()
    {
        var path = Path.Combine(Application.persistentDataPath, FileName);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<ScoreEntryList>(json);
        }
        else
        {
            return new ScoreEntryList();
        }
    }
    
    private static string VerifyPlayerName(string playerName)
    {
        return playerName != "" ? playerName : "user";
    }
}