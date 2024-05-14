using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private int _hearts = 3;
    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            if (_hearts > 0)
            {
                ResetPosition();
                _hearts--;
                Debug.Log("Current Hearts: " + _hearts);
            }
            else
            {
                KillPlayer();
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void ResetPosition()
    {
        transform.position = _initialPosition;
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
    }
}