using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HealthUiTests
    {
        private HealthUI _healthUI;
        private GameObject _healthUiGameObject;
        private GameObject _heartPrefab;

        [SetUp]
        public void Setup()
        {
            _healthUiGameObject = new GameObject("Main Camera");
            _healthUI = _healthUiGameObject.AddComponent<HealthUI>();

            _heartPrefab = new GameObject("HeartPrefab");

            var child = new GameObject("FullHeart");
            child.transform.parent = _heartPrefab.transform;
            child.AddComponent<SpriteRenderer>();

            _healthUI.heartPrefab = _heartPrefab;
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(_healthUiGameObject);
            Object.Destroy(_heartPrefab);
        }

        [UnityTest]
        public IEnumerator HealthUI_LevelIsLoading_3HeartsAreInitialized()
        {
            // Wait a frame for Start() to be called
            yield return null;

            // Assert that 3 hearts have been initialized
            Assert.AreEqual(3, _healthUiGameObject.transform.childCount);
        }

        [UnityTest]
        public IEnumerator HealthUI_PlayerHitBySpike_HeartsAreUpdatedTo2()
        {
            // Act
            _healthUI.UpdateHeart(2);

            // Skip a frame
            yield return null;

            // Assert
            Assert.AreEqual(3, _healthUI.HeartList.Count);

            for (var i = 0; i < 2; i++)
                Assert.IsTrue(_healthUI.HeartList[i].transform.Find("FullHeart").gameObject.activeSelf);
            Assert.IsFalse(_healthUI.HeartList[2].transform.Find("FullHeart").gameObject.activeSelf);
        }
    }
}