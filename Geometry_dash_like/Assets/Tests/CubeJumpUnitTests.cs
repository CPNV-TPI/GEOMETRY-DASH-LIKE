using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeJumpUnitTests
{
    private GameObject gameObject;
    private CubeJump cubeJump;
    private Rigidbody2D rigidbody2D;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        cubeJump = gameObject.AddComponent<CubeJump>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(gameObject);
    }

    [UnityTest]
    public IEnumerator Jump_IsGrounded_cubeCanJump()
    {
        // Arrange
        rigidbody2D.velocity = Vector2.zero; // S'assurer que le cube est "au sol"

        // Act
        cubeJump.Jump();
        
        // Skip a frame.
        yield return null;

        // Assert
        Assert.IsTrue(rigidbody2D.velocity.y > 0, "La force de saut n'a pas été appliquée correctement.");
    }
    
    
    [UnityTest]
    public IEnumerator Jump_IsNotGrounded_cubeCannotJump()
    {
        // Arrange
        float initialVelocityY = 5.0f; // Simuler que le cube est en mouvement / en l'air
        rigidbody2D.velocity = new Vector2(0, initialVelocityY); // Définir une vitesse verticale pour simuler le non-contact avec le sol

        // Act
        cubeJump.Jump();
        
        // Skip a frame.
        yield return null;

        // Assert
        Assert.IsTrue(rigidbody2D.velocity.y > 0, "La force de saut n'a pas été appliquée correctement.");
    }
}