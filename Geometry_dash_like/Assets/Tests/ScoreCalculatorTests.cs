using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ScoreCalculatorTests
    {
        private GameObject _player;
        private GameObject _finishLine;
        private ScoreCalculator _scoreCalculator;

        [SetUp]
        public void Setup()
        {
            // Create a GameObject for the player
            _player = new GameObject();
            _player.AddComponent<SpriteRenderer>().bounds.size.Set(1f, 1f, 0f);
            _player.transform.position = new Vector3(0f, 0f, 0f);
            _scoreCalculator = _player.AddComponent<ScoreCalculator>();

            // Create a GameObject for the finish line
            _finishLine = new GameObject();
            _finishLine.AddComponent<SpriteRenderer>().bounds.size.Set(1f, 1f, 0f); 
            _finishLine.transform.position = new Vector3(10f, 0f, 0f);
            
            _scoreCalculator.finishLine = _finishLine;
        }
        
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(_player);
            Object.Destroy(_finishLine);
        }
        
        [UnityTest]
        public IEnumerator ScoreCalculationTest()
        {
            var position = _player.transform.position;
            var initialPlayerPositionX = position.x;
            position = new Vector3(5f, 0f, 0f);
            _player.transform.position = position;
            
            var playerWidth = _player.GetComponent<SpriteRenderer>().bounds.size.x;
            var finishLineWidth = _finishLine.GetComponent<SpriteRenderer>().bounds.size.x;
            var levelLength = _finishLine.transform.position.x - initialPlayerPositionX - playerWidth / 2 - finishLineWidth / 2;
            var distanceTravelled = Mathf.Abs(position.x - initialPlayerPositionX);
            var expectedPercentageTravelled = distanceTravelled / levelLength * 100f;
            
            yield return null;
            
            Assert.AreEqual(expectedPercentageTravelled, _scoreCalculator.HigherPercentageTravelled);
        }
    }
}