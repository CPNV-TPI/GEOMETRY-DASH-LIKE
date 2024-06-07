using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    [SerializeField] private Text countdownText;
    private readonly LinkedList<(Vector3 position, float time)> _positionHistory = new();
    private Health _health;

    private PlayerMovementManager _playerMovementManager;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _playerMovementManager = GetComponent<PlayerMovementManager>();
    }

    private void Update()
    {
        GetPlayerPositionPerFrame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hearts = _health.Hearts;
        if (collision.gameObject.CompareTag("Finish")) KillPlayer();

        if (!collision.gameObject.CompareTag("Spike")) return;
        _health.RemoveHealth();
        if (hearts > 1)
            ResetPosition();
        else
            KillPlayer();
    }

    private void GetPlayerPositionPerFrame()
    {
        _positionHistory.AddLast((transform.position, Time.time));
        while (_positionHistory.Count > 0 && _positionHistory.First.Value.time < Time.time - 5)
            _positionHistory.RemoveFirst();
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
        EventManager.Instance.TriggerPlayerDeath();
    }

    private void ResetPosition()
    {
        if (_positionHistory.Count <= 0) return;
        _playerMovementManager.DisableMovement();
        var positionFrom5SecondsAgo = _positionHistory.First.Value.position;
        transform.position = positionFrom5SecondsAgo;
        _positionHistory.Clear();

        StartCoroutine(ReactivateMovementAfterDelay(3f));
    }


    private IEnumerator ReactivateMovementAfterDelay(float delay)
    {
        for (var i = (int)delay; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        _playerMovementManager.EnableMovement();
        countdownText.text = "";
    }
}