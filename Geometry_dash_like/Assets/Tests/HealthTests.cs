using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthTests
    {
        private Health _health;
        private GameObject _healthGameObject;

        [SetUp]
        public void Setup()
        {
            _healthGameObject = new GameObject();
            _health = _healthGameObject.AddComponent<Health>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(_healthGameObject);
        }

        [UnityTest]
        public IEnumerator Health_PlayerHitBySpike_DecreaseHealthByOne()
        {
            // Arrange
            var initialHealth = _health.Hearts;

            // Act
            _health.RemoveHealth();
            yield return null; // Skip a frame

            // Assert
            Assert.Less(_health.Hearts, initialHealth);
        }

        [UnityTest]
        public IEnumerator Health_PlayerHitBySpike_healingTimerIsRest()
        {
            // Arrange
            var initialHealingTimer = _health.HealingTimer;

            // Act
            yield return null; // Skip a frame
            _health.RemoveHealth();

            // Assert
            Assert.AreEqual(initialHealingTimer, _health.HealingTimer);
        }

        [UnityTest]
        public IEnumerator Health_PlayerDoesntHitFor30Sec_IncreaseHealByOne()
        {
            // Arrange
            var initialHealth = _health.Hearts;

            // Act
            _health.RemoveHealth();
            Time.timeScale = 30;
            yield return new WaitForSeconds(30);
            Time.timeScale = 1;

            // Assert
            Assert.AreEqual(initialHealth, _health.Hearts);
        }
    }
}