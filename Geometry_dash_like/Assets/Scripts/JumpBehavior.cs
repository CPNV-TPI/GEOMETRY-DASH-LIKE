using UnityEngine;

public abstract class JumpBehavior : MonoBehaviour
{
    protected const float JumpForce = 10f;

    protected Rigidbody2D RigidBody2D;

    private void Awake()
    {
        RigidBody2D = GetComponent<Rigidbody2D>();
    }

    public abstract void Jump();
}