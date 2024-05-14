using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private const float XOffset = -9f;
    public GameObject heartPrefab;
    
    private Health _health;
    private List<GameObject> _heartList;

    public void InitializeHearts(int maximumHealth)
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

    public void UpdateHeart(int hearts)
    {
        for (var i = 0; i < _heartList.Count; i++)
        {
            _heartList[i].transform.Find("FullHeart").gameObject.SetActive(i < hearts ? true : false);
        }
    }
}