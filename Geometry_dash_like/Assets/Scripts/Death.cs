using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private readonly LinkedList<(Vector3 position, float time)> _positionHistory = new();
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        GetPlayerPositionPerFrame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hearts = _health.Hearts;

        if (!collision.gameObject.CompareTag("Spike")) return;
        _health.RemoveHealth();
        if (hearts > 1)
        {
            ResetPosition();
        }
        else
        {
            KillPlayer();
        }
    }

    private void GetPlayerPositionPerFrame()
    {
        _positionHistory.AddLast((transform.position, Time.time));
        while (_positionHistory.Count > 0 && _positionHistory.First.Value.time < Time.time - 5)
            _positionHistory.RemoveFirst();
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