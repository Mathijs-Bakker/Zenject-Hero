using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code
{
	public class UIScore : MonoBehaviour
	{
		private Text _scoreTxt;
		private int Score { get; set; }

		private void Start()
		{
			_scoreTxt = GetComponent<Text>();
			_scoreTxt.text = "0";
		}

		public void UpdateScore(int points)
		{
			var temp = Score;
			var newScore = temp + points;
			_scoreTxt.text = newScore.ToString();
		}
	}
}
