using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeJumpUnitTests
{
    private GameObject _gameObject;
    private CubeJump _cubeJump;
    private Rigidbody2D _rigidbody2D;

    [SetUp]
    public void SetUp()
    {
        _gameObject = new GameObject();
        _cubeJump = _gameObject.AddComponent<CubeJump>();
        _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_gameObject);
    }

    [UnityTest]
    public IEnumerator Jump_IsGrounded_cubeCanJump()
    {
        // Arrange
        _rigidbody2D.velocity = Vector2.zero; 

        // Act
        _cubeJump.Jump();
        
        // Skip a frame.
        yield return null;

        // Assert
        Assert.IsTrue(_rigidbody2D.velocity.y > 0);
    }
    
    
    [UnityTest]
    public IEnumerator Jump_IsNotGrounded_cubeCannotJump()
    {
        // Arrange
        float initialVelocityY = 5.0f; 
        _rigidbody2D.velocity = new Vector2(0, initialVelocityY); 

        // Act
        _cubeJump.Jump();
        
        // Skip a frame.
        yield return null;

        // Assert
        Assert.AreEqual(initialVelocityY, _rigidbody2D.velocity.y, 0.01f);
    }
}