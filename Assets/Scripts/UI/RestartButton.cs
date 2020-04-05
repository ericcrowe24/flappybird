using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI {
    public class RestartButton : MonoBehaviour {
        private Button button;
        void Start() {
            button = GetComponent<Button>();
        }

        public void RestartPressed() {
            button.gameObject.SetActive(false);
            GameManager.Instance.RestartGame();
        }
    }
}
