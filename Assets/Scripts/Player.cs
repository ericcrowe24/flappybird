using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy {
    public class Player : MonoBehaviour {
        [SerializeField]
        private float jumpHeight = 5;
        [SerializeField]
        private float fallSpeed = 0.1f;

        private Rigidbody2D rb;

        private bool gameEnded = false;

        void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update() {
            if (GameManager.Instance.State == GameState.Started) {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    rb.velocity = new Vector2(0, jumpHeight);
                }
                else {
                    rb.velocity -= new Vector2(0, fallSpeed);
                }
            }

            if (GameManager.Instance.State == GameState.Ended) {
                rb.velocity -= new Vector2(0, fallSpeed);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision) {
            var tag = collision.collider.tag;
            if (tag == "Goal") {
                GameManager.Instance.UpdateScore(1);
            }
            else if (tag == "Coin") {
                GameManager.Instance.UpdateScore(5);
            }
            else if (tag == "PlayerOOB") {
                rb.velocity = new Vector2();
                enabled = false;
                GameManager.Instance.PlayerOffScreen();
            }
            else if (GameManager.Instance.State != GameState.Ended) {
                GameManager.Instance.EndGame();
            }
        }
    }
}
