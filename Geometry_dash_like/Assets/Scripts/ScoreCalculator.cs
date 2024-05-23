using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject finishLine;
    public int levelIndex;
    private float _finishLineWidth;
    private float _initialPlayerPositionX;
    private float _levelLength;
    private float _playerWidth;
    public float HigherPercentageTravelled { get; private set; }

    private void Start()
    {
        _initialPlayerPositionX = transform.position.x;
        _playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        _finishLineWidth = finishLine.GetComponent<SpriteRenderer>().bounds.size.x;
        _levelLength = finishLine.transform.position.x - _initialPlayerPositionX - _playerWidth / 2 - _finishLineWidth / 2;
    }

    private void Update()
    {
        ScoreCalculation();
    }

    private void ScoreCalculation()
    {
        var distanceTravelled = Mathf.Abs(transform.position.x - _initialPlayerPositionX);
        var percentageTravelled = distanceTravelled / _levelLength * 100f;
        if (percentageTravelled > 100) HigherPercentageTravelled = 100;
        else if (HigherPercentageTravelled < percentageTravelled) HigherPercentageTravelled = percentageTravelled;
    }
}