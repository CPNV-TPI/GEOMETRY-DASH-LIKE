using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UfoJump : MonoBehaviour, IJumpBehavior
{
    private const float JumpForce = 10f;

    private Rigidbody2D _rigidBody2D;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rigidBody2D.velocity = new Vector2(_rigidBody2D.velocity.x, 0);
        _rigidBody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
}