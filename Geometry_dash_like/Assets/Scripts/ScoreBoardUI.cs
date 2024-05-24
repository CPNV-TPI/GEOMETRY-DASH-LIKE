using UnityEngine;
using UnityEngine.UI;

public class ScoreBoardUI : MonoBehaviour
{
    public GameObject scorePrefab;

    public void InitializeScores(string levelIndex)
    {
        var dataList = ScoreManager.LoadScoreFromJson();
        var panel = transform.Find("Background/Scroll/Panel");

        foreach (Transform child in panel) Destroy(child.gameObject);

        foreach (var scoreEntry in dataList.scoreEntryList)
        {
            if (scoreEntry.levelIndex != levelIndex) continue;
            var position = new Vector3(0, 0, 0);
            var score = Instantiate(scorePrefab, position, Quaternion.identity);

            score.transform.SetParent(panel, false);

            score.transform.Find("PlayerName").GetComponent<Text>().text = scoreEntry.playerName;
            score.transform.Find("Score").GetComponent<Text>().text = scoreEntry.score;
        }
    }
}