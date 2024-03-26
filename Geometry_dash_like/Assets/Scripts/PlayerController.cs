using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CubeJump _cubeJump;

    private void Awake()
    {
        _cubeJump = GetComponent<CubeJump>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _cubeJump.Jump();
        }
    }
    
}
