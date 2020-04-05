using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Flappy.UI {
    public class ScoreText : MonoBehaviour {
        private TextMeshProUGUI text;

        void Start() {
            text = GetComponent<TextMeshProUGUI>();
        }

        void Update() {
            text.text = GameManager.Instance.Score.ToString();
        }
    }
}
