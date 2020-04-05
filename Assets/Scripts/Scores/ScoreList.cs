using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

namespace Flappy.Scores {
    [XmlRoot(nameof(Scores))]
    public class ScoreList {
        [XmlArray, XmlArrayItem("Score")]
        public List<int> Scores;

        private object lockObject = new object();

        public ScoreList() {
            Scores = new List<int>();
        }

        public void AddScore(int score) {
            Scores.Add(score);

            Scores.Sort((a, b) => b.CompareTo(a));

            if (Scores.Count > 10)
                Scores.RemoveAt(Scores.Count - 1);
        }

        public void Save(string path) {
            var serializer = new XmlSerializer(typeof(ScoreList));

            using (var stream = new FileStream(path, FileMode.Create)) {
                serializer.Serialize(stream, this);
            }
        }

        public static ScoreList Load(string path) {
            var serializer = new XmlSerializer(typeof(ScoreList));

            using (var stream = new FileStream(path, FileMode.Open)) {
                return serializer.Deserialize(stream) as ScoreList;
            }
        }
    }
}
