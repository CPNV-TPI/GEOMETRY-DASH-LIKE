using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ForwardMovementUnitTest
{
    private GameObject _gameObject;

    [SetUp]
    public void SetUp()
    {
        _gameObject = new GameObject("Player");
        _gameObject.AddComponent<ForwardMovement>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_gameObject);
    }

    [UnityTest]
    public IEnumerator ForwardMovement_MovesObjectForward()
    {
        // Arrange
        Vector3 initialPosition = _gameObject.transform.position;

        // Act
        yield return null;

        // Skip a frame.
        Vector3 newPosition = _gameObject.transform.position;

        // Assert
        Assert.IsTrue(newPosition.x > initialPosition.x);
    }
}
