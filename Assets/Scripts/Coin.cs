using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public static bool IsActive = false;
    // Start is called before the first frame update
    void Start() {
        IsActive = true;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "CoinDeleter" || collision.gameObject.name == "Player") {
            IsActive = false;
            Destroy(gameObject);
        }
    }
}
