using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace Flappy.UI {
    public class HighScoresPanel : MonoBehaviour {
        [SerializeField]
        private TextMeshProUGUI text;

        public void UpdateHighScores() {
            text.text = "";
            var scores = GameManager.Instance.scoreList.Scores;
            for(int i = 0; i < 10; i++) {
                text.text += (i + 1).ToString() + ". ";

                if(i < scores.Count) {
                    text.text += scores[i].ToString();
                }
                else {
                    text.text += "nothing";
                }

                text.text += "\n";
            }
        }
    }
}
