using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CubeJump : JumpBehavior
{
    private const float GroundThreshold = 0.01f;

    public override void Jump()
    {
        if (IsGrounded()) RigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(RigidBody2D.velocity.y) < GroundThreshold;
    }
}