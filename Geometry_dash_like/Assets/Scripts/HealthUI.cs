using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private const float XOffset = -9f;
    public GameObject heartPrefab;
    private const int MaximumHearts  = 3;
    
    private List<GameObject> _heartList;
    
    
    private void Start()
    {
        EventManager.Instance.OnHealthChanged += UpdateHeart;
        InitializeHearts(MaximumHearts);
    }

    private void InitializeHearts(int maximumHealth)
    {
        _heartList = new List<GameObject>();
        var prefabLength = heartPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;

        for (var i = 0; i < maximumHealth; i++)
        {
            var position = new Vector3(XOffset + prefabLength * i, 4, 15);
            var heart = Instantiate(heartPrefab, position, Quaternion.identity);
            heart.transform.parent = gameObject.transform;
            _heartList.Add(heart);
        }
    }

    private void UpdateHeart(int hearts)
    {
        for (var i = 0; i < _heartList.Count; i++)
        {
            _heartList[i].transform.Find("FullHeart").gameObject.SetActive(i < hearts ? true : false);
        }
    }
}