using UnityEngine;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "ScoreData", menuName = "Biweekly/Week 1/Score Data", order = 0)]
	public sealed class ScoreData : ScriptableObject
	{
		private int _score = 0;

		public int Score => _score;

		public void IncreaseScore(int amount)
		{
			if (amount <= 0) return;

			_score += amount;
		}

		public void ResetScore()
		{
			_score = 0;
		}
	}
}