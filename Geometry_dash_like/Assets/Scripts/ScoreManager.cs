using System.IO;
using UnityEngine;

public class ScoreManager
{
    private const string FileName = "score.json";
    private readonly ScoreEntry _scoreEntry;

    public ScoreManager(string playerName, string score, string levelIndex)
    {
        _scoreEntry = new ScoreEntry
        {
            playerName = VerifyPlayerName(playerName),
            score = score,
            levelIndex = levelIndex
        };
    }

    public void SaveScoreToJson()
    {
        var dataList = LoadScoreFromJson();

        dataList.scoreEntryList.Add(_scoreEntry);

        var json = JsonUtility.ToJson(dataList, true);
        var path = Path.Combine(Application.persistentDataPath, FileName);
        File.WriteAllText(path, json);
    }

    public static ScoreEntryList LoadScoreFromJson()
    {
        var path = Path.Combine(Application.persistentDataPath, FileName);
        if (!File.Exists(path)) return new ScoreEntryList();
        var json = File.ReadAllText(path);
        return JsonUtility.FromJson<ScoreEntryList>(json);
    }

    private static string VerifyPlayerName(string playerName)
    {
        return playerName != "" ? playerName : "User";
    }
}