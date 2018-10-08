using UnityEngine;
using UnityEngine.UI;

namespace UI.Score.Code
{
    public class Score : MonoBehaviour
    {
        private Text _scoreTxt;
        private int Points { get; set; }

        private void Start()
        {
            _scoreTxt = GetComponent<Text>();
            _scoreTxt.text = "0";
        }

        public void AddPoints(int scorePoints)
        {
            Points += scorePoints;
            _scoreTxt.text = Points.ToString();
        }
    }
}