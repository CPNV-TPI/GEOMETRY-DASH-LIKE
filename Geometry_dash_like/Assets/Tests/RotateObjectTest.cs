using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RotateObjectTest
    {
        private GameObject _gameObject;

        [SetUp]
        public void SetUp()
        {
            // Create a new GameObject and add the RotateObject component to it
            _gameObject = new GameObject("Player");
            _gameObject.AddComponent<RotateObject>();
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up after each test
            Object.DestroyImmediate(_gameObject);
        }

        [UnityTest]
        public IEnumerator RotateObject_NoConditions_TheObjectRolls()
        {
            // Arrange
            var initialRotation = _gameObject.transform.rotation;

            // Act
            yield return null; // Skip a frame

            //warining : Rider doesn't understand what we are going to do with the variable, but it's not an error.
            //https://gamedev.stackexchange.com/questions/174559/is-it-really-more-efficient-to-have-a-local-variable-for-transform-here-or-is-ri
            var newRotation = _gameObject.transform.rotation;

            // Assert
            Assert.IsTrue(initialRotation.z > newRotation.z, "Rotation should be negative after one frame.");
        }
    }
}