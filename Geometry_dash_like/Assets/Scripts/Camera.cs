using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _currentVelocity;
    private readonly Vector3 _offset = new(5, 0, -10);
    private readonly float _smoothTime = 0.25f;

    private readonly float _startFollowingPosition = -5.25f;

    // Update is called once per frame
    private void Update()
    {
        if (!_player) return;
        FollowPlayer();
    }

    private void FollowPlayerX(float yPosition)
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(_player.position.x, yPosition, _player.position.z) + _offset,
            ref _currentVelocity,
            _smoothTime
        );
    }

    private void FollowPlayerY(float yPosition)
    {
        if (_player.position.x >= _startFollowingPosition)
        {
            if (_player.position.y >= transform.position.y + 3) yPosition = transform.position.y + 2;

            if (_player.position.y <= transform.position.y - 5) yPosition = transform.position.y - 2;

            FollowPlayerX(yPosition);
        }
    }

    private void FollowPlayer()
    {
        FollowPlayerY(0);
    }
}