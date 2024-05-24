using UnityEngine;

public class Camera : MonoBehaviour
{
    private const float SmoothTime = 0.25f;
    private const float StartFollowingPosition = -5.25f;
    
    [SerializeField] private Transform player;
    private readonly Vector3 _offset = new(5, 0, -10);
    private Vector3 _currentVelocity;
    
    private void Update()
    {
        if (!player) return;
        FollowPlayer();
    }

    private void FollowPlayerX(float yPosition)
    {
        transform.position = Vector3.SmoothDamp(
            transform.position,
            new Vector3(player.position.x, yPosition, player.position.z) + _offset,
            ref _currentVelocity,
            SmoothTime
        );
    }

    private void FollowPlayerY(float yPosition)
    {
        if (player.position.x < StartFollowingPosition) return;
        if (player.position.y >= transform.position.y + 3) yPosition = transform.position.y + 2;
        if (player.position.y <= transform.position.y - 5) yPosition = transform.position.y - 2;
        FollowPlayerX(yPosition);
    }

    private void FollowPlayer()
    {
        FollowPlayerY(0);
    }
}