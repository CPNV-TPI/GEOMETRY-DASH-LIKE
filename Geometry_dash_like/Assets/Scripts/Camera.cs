using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Transform _player;
    private Vector3 _offset = new Vector3(5, 0, -10);
    private float _smoothTime = 0.25f;
    private Vector3 _currentVelocity;

    private float _startFollowingPosition = -5.25f;

    // Update is called once per frame
    void Update()
    {
        if (_player.position.x >= _startFollowingPosition)
        {
            float yPosition = 0;

            if (_player.position.y >= (transform.position.y + 3))
            {
                yPosition = (transform.position.y + 2);
            }

            if (_player.position.y <= (transform.position.y - 5))
            {
                yPosition = (transform.position.y - 2);
            }

            FollowPlayer(yPosition);
        }

    }

    private void FollowPlayer(float yPosition)
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(_player.position.x, yPosition, _player.position.z) + _offset,
            ref _currentVelocity,
            _smoothTime
        );

    }
}
