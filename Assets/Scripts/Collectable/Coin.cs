using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.Collectable {
    public class Coin : MonoBehaviour {
        private Rigidbody2D rb2d;

        private void Start() {
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (GameManager.Instance.State == GameState.Ended) {
                rb2d.velocity = new Vector2();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var tag = collision.collider.tag;
            if (tag == "ObjectDestroyer" || tag == "Player") {
                Destroy(gameObject);
            }
        }
    }
}
