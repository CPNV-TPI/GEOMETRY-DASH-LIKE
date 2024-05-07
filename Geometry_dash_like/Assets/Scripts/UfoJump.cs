using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UfoJump : MonoBehaviour, IJumpBehavior
{
    private readonly float _jumpForce = 10f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
       _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}