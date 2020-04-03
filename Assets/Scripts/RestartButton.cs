using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour {
    private Button button;
    // Start is called before the first frame update
    void Start() {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update() {

    }



    public void RestartPressed() {
        button.gameObject.SetActive(false);
        GameManager.Instance.RestartGame();
    }
}
