using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Death : MonoBehaviour
{
    private int _hearts = 3;
    private LinkedList<(Vector3 position, float time)> _positionHistory = new LinkedList<(Vector3, float)>();
    private float _healing;
    private HealthUI _healthUI;

    private void Start()
    {
        _healthUI = GameObject.Find("Main Camera").GetComponent<HealthUI>();
    }

    private void Update()
    {
        if (_hearts < 3)
        {
            _healing -= Time.deltaTime;
            if (_healing <= 0)
            {
                _hearts++;
                _healthUI.UpdateHeart(_hearts);
                _healing = 30f;
            }
        }
        
        _positionHistory.AddLast((transform.position, Time.time));
        while (_positionHistory.Count > 0 && _positionHistory.First.Value.time < Time.time - 5)
        {
            _positionHistory.RemoveFirst();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Spike")) return;
        if (_hearts > 0)
        {
            ResetPosition();
            _hearts--;
            _healthUI.UpdateHeart(_hearts);
            _healing = 30f;
            Debug.Log("Current Hearts: " + _hearts);
        }
        else
        {
            KillPlayer();
        }
        
    }

    private void ResetPosition()
    {
        if (_positionHistory.Count < 0) return;
        var positionFrom5SecondsAgo = _positionHistory.First.Value.position;
        transform.position = positionFrom5SecondsAgo;
        
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
    }


}