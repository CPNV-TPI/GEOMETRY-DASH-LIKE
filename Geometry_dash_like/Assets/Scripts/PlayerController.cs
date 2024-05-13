using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JumpBehavior _jumpBehavior;

    private void Awake()
    {
        _jumpBehavior = GetComponent<JumpBehavior>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _jumpBehavior.Jump();
    }
}