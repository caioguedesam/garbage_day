using Common;
using UnityEngine;

namespace Biweekly
{
	public sealed class ScoreController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private ScoreData _scoreData = null;
		[SerializeField]
		private GameDifficultyController _difficultyController = null;

		[Header("Events")]
		[SerializeField]
		private IntUnityEvent _onScoreUpdate = null;

		private void Start()
		{
			ResetScore();
		}

		private void ResetScore()
		{
			_scoreData.ResetScore();
			PropagateScoreChange();
		}

		public void IncreaseScore()
		{
			int increase = _difficultyController.CurrentDifficultyIncrement.scorePerPickup;
			_scoreData.IncreaseScore(increase);
			PropagateScoreChange();
		}

		private void PropagateScoreChange()
		{
			_onScoreUpdate.Invoke(_scoreData.Score);
		}
	}
}