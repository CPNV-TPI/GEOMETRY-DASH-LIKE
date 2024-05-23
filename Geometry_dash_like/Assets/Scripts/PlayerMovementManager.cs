using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    private ForwardMovement _forwardMovement;
    private Rigidbody2D _rigidBody2D;
    private PlayerController _playerController;

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _forwardMovement = GetComponent<ForwardMovement>();
        _playerController = GetComponent<PlayerController>();
    }

    public void DisableMovement() {
        _rigidBody2D.simulated = false;
        _forwardMovement.enabled = false;
        _playerController.enabled = false;
    } 
    
    public void EnableMovement() {
        _rigidBody2D.simulated = true;
        _forwardMovement.enabled = true;
        _playerController.enabled = true;
    }
}


