using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "GameDifficultyData", menuName = "Biweekly/Week 1/Game Difficulty Data", order = 0)]
	public sealed class GameDifficultyData : ScriptableObject
	{
		[SerializeField]
		private List<GameDifficultyIncrement> _difficultyIncrements = new List<GameDifficultyIncrement>();

		public GameDifficultyIncrement this[int index] => _difficultyIncrements[index];
		public int Count => _difficultyIncrements.Count;
	}
}