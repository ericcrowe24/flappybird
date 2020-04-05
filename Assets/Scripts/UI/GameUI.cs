using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI {
    public class GameUI : MonoBehaviour {
        [SerializeField]
        private HighScoresPanel highScoresPanel;

        [SerializeField]
        private RestartButton restartButton;

        [SerializeField]
        private ExitButton exitButton;

        private float timeSinceEnded = 0;

        void Update() {
            if (!GameManager.Instance.PlayerOnScreen) {
                highScoresPanel.UpdateHighScores();
                highScoresPanel.gameObject.SetActive(true);
                restartButton.gameObject.SetActive(true);
                exitButton.gameObject.SetActive(true);
            }
        }

        public void RestartPressed() {
            restartButton.gameObject.SetActive(false);
            GameManager.Instance.RestartGame();
        }
    }
}
