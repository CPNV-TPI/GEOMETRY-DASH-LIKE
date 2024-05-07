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
        // Annule la composante verticale de la vitesse
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);

        // Ajoute une force ascendante
        _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}