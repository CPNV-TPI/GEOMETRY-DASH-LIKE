using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CubeJump : MonoBehaviour, IJumpBehavior
{
    private const float JumpForce = 10f;
    private const float GroundThreshold = 0.01f;

    private Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (IsGrounded()) _rigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(_rigidBody2D.velocity.y) < GroundThreshold;
    }
}