using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI {
    public class StartButton : MonoBehaviour {
        private Button button;
        void Start() {
            button = GetComponent<Button>();
        }

        void Update() {

        }

        public void StartPressed() {
            button.gameObject.SetActive(false);
            GameManager.Instance.StartGame();
        }
    }
}
