using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
    [SerializeField]
    private Button button;

    private float timeSinceEnded = 0;

    void Update() {
        if (GameManager.Instance.GameEnded && timeSinceEnded < 1) {
            timeSinceEnded += Time.deltaTime;
            if (timeSinceEnded >= 1) {
                button.gameObject.SetActive(true);
            }
        }
    }

    public void RestartPressed() {
        button.gameObject.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
