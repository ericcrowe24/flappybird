using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.UI {
    public class ExitButton : MonoBehaviour {
        public void ExitButtonPressed() {
            GameManager.Instance.ExitGame();
        }
    } 
}
