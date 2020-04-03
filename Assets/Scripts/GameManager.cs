using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private static object lockObj = new object();
    private static GameManager instance;

    public bool GameStarted = false;
    public bool GameEnded = false;
    public int Score = 0;

    private GameManager() { }

    public static GameManager Instance {
        get {
            lock (lockObj) {
                if (instance == null) {
                    instance = (GameManager) FindObjectOfType(typeof(GameManager));

                    if (instance == null) {
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<GameManager>();
                        singletonObject.name = nameof(GameManager);
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return instance;
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }

    public void StartGame() {
        GameStarted = true;
    }

    public void UpdateScore() {
        Score += 1;
    }

    public void EndGame() {
        GameEnded = true;
        GameStarted = false;
        PipeSpawner.GameEnded = true;
        Pipe.GameEnded = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Score = 0;
        GameStarted = false;
        GameEnded = false;
        PipeSpawner.GameEnded = false;
        Pipe.GameEnded = false;
    }
}
