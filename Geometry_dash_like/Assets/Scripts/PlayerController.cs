using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IJumpBehavior _jumpBehavior;

    private void Awake()
    {
        _jumpBehavior = GetComponent<IJumpBehavior>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpBehavior.Jump();
        }
    }
    
}
