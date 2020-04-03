using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour {
    [SerializeField]
    private MonoBehaviour coin;

    private float timeSinceLastCoinSpawn;
    private float maxCoinHeight = 2.8f;
    private float minCoinHeight = -1.3f;
    private float maxSpeed = -10f;
    private float minspeed = -5f;
    // Update is called once per frame
    void Update() {
        if (GameManager.Instance.GameStarted && !GameManager.Instance.GameEnded) {
            timeSinceLastCoinSpawn += Time.deltaTime;
            if(timeSinceLastCoinSpawn > 1 && Random.value >= 0.9f && !Coin.IsActive) {
                timeSinceLastCoinSpawn = 0;
                SpawnCoin();
            }
        }
    }

    private void SpawnCoin() {
        Vector3 spawnPoint = new Vector3(0, Random.Range(minCoinHeight, maxCoinHeight), 0);
        Vector2 velocity = new Vector2(Random.Range(minspeed, maxSpeed), 0);
        var instance = Instantiate(coin, transform);
        instance.transform.Translate(spawnPoint);
        instance.name = "Coin";
        instance.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
