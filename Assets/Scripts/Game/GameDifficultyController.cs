using System.Collections;
using UnityEngine;

namespace Biweekly
{
	public sealed class GameDifficultyController : MonoBehaviour
	{
		[SerializeField]
		private GameDifficultyData _difficultyData = null;
		private int _currentDifficultyIndex = 0;

		private GameDifficultyIncrement _currentDifficultyIncrement = null;

		public GameDifficultyIncrement CurrentDifficultyIncrement => _currentDifficultyIncrement;

		private void Start()
		{
			_currentDifficultyIncrement = _difficultyData[_currentDifficultyIndex];
			StartCoroutine(DifficultyIncreasingRoutine());
		}

		private IEnumerator DifficultyIncreasingRoutine()
		{
			while (_currentDifficultyIndex < _difficultyData.Count - 1)
			{
				yield return new WaitForSeconds(_currentDifficultyIncrement.timeUntilNextIncrement);
				_currentDifficultyIncrement = _difficultyData[++_currentDifficultyIndex];
				Debug.Log($"Increased to difficulty {_currentDifficultyIndex}");
			}
		}
	}
}