using System.Collections;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using Flappy.Utility;
using Flappy.Scores;

namespace Flappy {
    public class GameManager : Singleton<GameManager> {
        public GameState State;
        public int Score = 0;
        public bool PlayerOnScreen = true;

        public ScoreList scoreList { get; private set; } = new ScoreList();

        private const string scoreListFileName = "scores.xml";

        private GameManager() { }

        private void Start() {
            DontDestroyOnLoad(this);
            State = GameState.Waiting;
            SceneManager.LoadScene("Main");
            LoadScores();
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                ExitGame();
            }
        }

        private void LoadScores() {
            try {
                scoreList = ScoreList.Load(GetScoreListPath());
            }
            catch (FileNotFoundException) {
                Debug.Log("Score List not found, creating " + scoreListFileName);
                scoreList.Save(GetScoreListPath());
                scoreList = ScoreList.Load(GetScoreListPath());
            }
        }

        private string GetScoreListPath() {
            return Path.Combine(Application.persistentDataPath, scoreListFileName);
        }

        public void StartGame() {
            State = GameState.Started;
        }

        public void UpdateScore(int score) {
            if (State == GameState.Started)
                Score += score;
        }

        public void EndGame() {
            scoreList.AddScore(Score);
            scoreList.Save(GetScoreListPath());
            State = GameState.Ended;
        }

        public void PlayerOffScreen() {
            PlayerOnScreen = false;
        }

        public void RestartGame() {
            State = GameState.Restarting;
            PlayerOnScreen = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score = 0;
            State = GameState.Restarted;
        }

        public void ExitGame() {
            Application.Quit();
        }
    }

    public enum GameState {
        Waiting, Started, Ended, Restarting, Restarted
    }
}
