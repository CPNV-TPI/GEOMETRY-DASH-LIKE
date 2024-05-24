using System.Collections.Generic;

[System.Serializable]
public class ScoreEntry
{
    public string playerName;
    public string score;
    public string levelIndex;
}

[System.Serializable]
public class ScoreEntryList
{
    public List<ScoreEntry> scoreEntryList = new List<ScoreEntry>();
}