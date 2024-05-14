using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UfoJumpTests
    {
        private GameObject _gameObject;
        private Rigidbody2D _rigidBody2D;

        [SetUp]
        public void SetUp()
        {
            // Create a new GameObject and add the UfoJump component to it
            _gameObject = new GameObject("UFO");
            _rigidBody2D = _gameObject.AddComponent<Rigidbody2D>();
            _gameObject.AddComponent<UfoJump>();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Object.DestroyImmediate(_gameObject);
        }

        [UnityTest]
        public IEnumerator Jump_IsGrounded_UfoCanJump()
        {
            // Arrange
            _rigidBody2D.velocity = Vector2.zero;

            // Act
            _gameObject.GetComponent<UfoJump>().Jump();

            // Skip a frame
            yield return null;

            // Assert
            Assert.IsTrue(_rigidBody2D.velocity.y > 0);
        }

        [UnityTest]
        public IEnumerator Jump_IsNotGrounded_UfoCanJump()
        {
            // Arrange
            _rigidBody2D.velocity = new Vector2(0, 5.0f);

            // Act
            _gameObject.GetComponent<UfoJump>().Jump();

            // Skip a frame
            yield return null;

            // Assert
            Assert.IsTrue(_rigidBody2D.velocity.y > 0);
        }
    }
}