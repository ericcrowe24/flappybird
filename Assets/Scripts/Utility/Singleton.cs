using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Flappy.Utility {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static bool shuttingDown = false;
        private static object lockObject = new object();
        private static T instance;

        public static T Instance {
            get {
                if (shuttingDown) {
                    Debug.Log("[Singleton] Instance '" + typeof(T) + "' already destoryed.");
                    return null;
                }

                lock (lockObject) {
                    instance = (T) FindObjectOfType(typeof(T));

                    if (instance == null) {
                        var singleton = new GameObject();
                        instance = singleton.AddComponent<T>();
                        instance.name = typeof(T).ToString();

                        DontDestroyOnLoad(singleton);
                    }

                    return instance;
                }
            }
        }

        private void OnApplicationQuit() {
            shuttingDown = true;
        }

        private void OnDestroy() {
            shuttingDown = true;
        }
    }
}
