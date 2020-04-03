using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    private Button button;
    // Start is called before the first frame update
    void Start() {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartPressed() {
        button.gameObject.SetActive(false);
        GameManager.Instance.StartGame();
    }
}
