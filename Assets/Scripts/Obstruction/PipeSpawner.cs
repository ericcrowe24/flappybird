﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Flappy.Obstruction {
    public class PipeSpawner : MonoBehaviour {
        [SerializeField]
        private MonoBehaviour pipe;

        public static bool GameEnded = false;

        private float timeSincePipeSpawn = 0;
        private bool gameJustStarted = true;

        private float pipeSpawnDelay = 50f / 60f;
        private float pipeStartHeight = 0.1f;
        private float pipeMaxHeight = 2.4f;
        private float pipeMinHeight = -1.3f;
        private float lastPipeHeight = 0.1f;
        private float speed = -10f;

        void Update() {
            if (GameManager.Instance.State == GameState.Started) {
                if (gameJustStarted) {
                    SpawnPipe();
                    gameJustStarted = false;
                }
                else {
                    timeSincePipeSpawn += Time.deltaTime;
                    if (timeSincePipeSpawn >= pipeSpawnDelay) {
                        timeSincePipeSpawn = 0;
                        SpawnPipe();
                    }
                }
            }
        }

        private void SpawnPipe() {
            var inst = Instantiate(pipe, transform);
            if (gameJustStarted) {
                inst.transform.Translate(new Vector3(0, pipeStartHeight, 0));
                inst.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
                inst.transform.Translate(new Vector3(0, pipeStartHeight, 0));
            }
            else {
                float min = lastPipeHeight - 2;
                float max = lastPipeHeight + 2;
                float height = Random.Range(min < pipeMinHeight ? pipeMinHeight : min, max > pipeMaxHeight ? pipeMaxHeight : max);
                lastPipeHeight = height;
                inst.transform.Translate(new Vector3(0, height, 0));

                if (GameManager.Instance.Score % 10 == 0 && pipeSpawnDelay >= 10f / 60f) {
                    pipeSpawnDelay *= 0.85f;
                }

                inst.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            }
        }
    }
}
