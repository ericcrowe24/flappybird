using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (GameManager.Instance.GameStarted) {
            if (Input.GetKeyDown(KeyCode.Space) && !GameManager.Instance.GameEnded) {
                rb.velocity = new Vector2(0, jumpHeight);
            }
            else {
                rb.velocity -= new Vector2(0, fallSpeed);
            }
        }

        if (GameManager.Instance.GameEnded) {
            rb.velocity -= new Vector2(0, fallSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Goal" && !GameManager.Instance.GameEnded) {
            GameManager.Instance.UpdateScore();
        }
        else {
            GameManager.Instance.EndGame();
        }
    }
}
