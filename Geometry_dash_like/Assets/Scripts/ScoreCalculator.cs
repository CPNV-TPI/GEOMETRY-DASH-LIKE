using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    public GameObject finishLine;
    public int levelIndex;
    
    private float _levelLength; 
    private float _initialPlayerPositionX;
    private float _playerWidth;
    private float _finishLineWidth;
    private float _higherPercentageTravelled = 0;

    private void Start()
    {
        _initialPlayerPositionX = transform.position.x; 
        _playerWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        _finishLineWidth = finishLine.GetComponent<SpriteRenderer>().bounds.size.x;
        _levelLength = finishLine.transform.position.x - _initialPlayerPositionX - (_playerWidth / 2) - (_finishLineWidth / 2);
    }

    private void Update()
    {
        var distanceTravelled = Mathf.Abs(transform.position.x - _initialPlayerPositionX); // Calculer la distance parcourue
        var percentageTravelled = (distanceTravelled / _levelLength) * 100f; // Calculer le pourcentage parcouru
        if (percentageTravelled > 100) _higherPercentageTravelled = 100;
        else
        if (_higherPercentageTravelled < percentageTravelled) _higherPercentageTravelled = percentageTravelled;

        Debug.Log("Pourcentage parcouru : " + _higherPercentageTravelled.ToString("F2") + "%");
    }
}