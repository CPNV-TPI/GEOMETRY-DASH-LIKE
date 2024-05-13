using UnityEngine;

public class UfoJump : JumpBehavior
{
    public override void Jump()
    {
        RigidBody2D.velocity = new Vector2(RigidBody2D.velocity.x, 0);

        RigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
}