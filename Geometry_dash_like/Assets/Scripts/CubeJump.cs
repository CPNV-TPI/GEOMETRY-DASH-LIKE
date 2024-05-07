
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CubeJump : MonoBehaviour, IJumpBehavior
{
    private float _jumpForce = 10f; 
    private Rigidbody2D _rigidbody2D;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    public void Jump()
    {

        if (IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float threshold = 0.01f;

        return Mathf.Abs(_rigidbody2D.velocity.y) < threshold;
    }


}
