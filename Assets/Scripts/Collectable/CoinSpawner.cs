using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.Collectable {
    public class CoinSpawner : MonoBehaviour {
        [SerializeField]
        private MonoBehaviour coinPrefab;

        private Coin coin;
        private float timeSinceLastCoinSpawn;
        private float maxCoinHeight = 2.8f;
        private float minCoinHeight = -1.3f;
        private float maxSpeed = -15f;
        private float minspeed = -5f;

        void Update() {
            if (GameManager.Instance.State == GameState.Started) {
                if (coin == null) {
                    timeSinceLastCoinSpawn += Time.deltaTime;

                    var roll = Random.value;
                    if (timeSinceLastCoinSpawn >= 1 && roll >= 0.9f) {
                        timeSinceLastCoinSpawn = 0;
                        SpawnCoin();
                    }
                    if (timeSinceLastCoinSpawn >= 1 && roll < 0.9f) {
                        timeSinceLastCoinSpawn = 0;
                    }
                }
            }
        }

        private void SpawnCoin() {
            Vector3 spawnPoint = new Vector3(0, Random.Range(minCoinHeight, maxCoinHeight), 0);
            Vector2 velocity = new Vector2(Random.Range(minspeed, maxSpeed), 0);
            coin = (Coin) Instantiate(coinPrefab, transform);
            coin.transform.Translate(spawnPoint);
            coin.name = "Coin";
            coin.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
}
