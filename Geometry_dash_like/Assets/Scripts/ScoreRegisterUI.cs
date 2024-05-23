using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreRegisterUI : MonoBehaviour
{
    public Text scoreText;
    public GameObject scoreRegisterDisplay;
    public GameObject scoreCalculationObject;
    public int levelIndex;
    private float _higherPercentageTravelled;
    private ScoreCalculator _scoreCalculator;

    private void Start()
    {
        EventManager.Instance.OnPlayerDeath += DisplayScore;
        _scoreCalculator = scoreCalculationObject.GetComponent<ScoreCalculator>();
    }

    private void DisplayScore()
    {
        _higherPercentageTravelled = _scoreCalculator.HigherPercentageTravelled;
        scoreText.text = _higherPercentageTravelled.ToString("F2") + "%";
        scoreRegisterDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }
}