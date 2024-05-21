using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DeathTests
    {
        private Death _death;
        private Health _health;
        private GameObject _player;

        [SetUp]
        public void Setup()
        {
            _player = new GameObject();
            _player.AddComponent<BoxCollider2D>();
            _player.AddComponent<Rigidbody2D>();
            _player.transform.position = new Vector3(0, 0, 0);
            _health = _player.AddComponent<Health>();
            _death = _player.AddComponent<Death>();
        }

        [TearDown]
        public void Teardown()
        {
        }

        [UnityTest]
        public IEnumerator Death_PlayerCollisionWithSpike_DecreaseHealthByOne()
        {
            var initialHealth = _health.Hearts;

            // Create a spike
            var spike = new GameObject();
            spike.tag = "Spike";

            // Assert
            Assert.AreEqual(initialHealth, _health.Hearts);

            // Act
            spike.AddComponent<BoxCollider2D>();
            _player.transform.position = spike.transform.position + new Vector3(0, -1, 0);

            // Skip a second
            yield return new WaitForSeconds(1);
            ;

            // Vérifier que la santé du joueur a été réduite de un
            Assert.AreEqual(initialHealth - 1, _health.Hearts);
        }

        [UnityTest]
        public IEnumerator Death_PlayerHit3Times_PlayerIsDestroy()
        {
            var initialHealth = _health.Hearts;

            // Create a spike
            var spike = new GameObject();
            spike.tag = "Spike";

            // Assert
            Assert.AreEqual(initialHealth, _health.Hearts);

            // act
            spike.AddComponent<BoxCollider2D>();
            _player.transform.position = spike.transform.position + new Vector3(0, -1, 0);
            Time.timeScale = 2;
            while (_player != null)
            {
                _player.transform.position = spike.transform.position + new Vector3(0, -1, 0);
                yield return new WaitForSeconds(1);
            }

            Time.timeScale = 1;

            Assert.IsFalse(_player);
        }
    }
}