using TMPro;
using UnityEngine;

namespace Biweekly
{
	public sealed class UIScore : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _scoreText = null;
		[SerializeField]
		private string _beforeText = "";
		[SerializeField]
		private string _afterText = "";

		public void UpdateScoreUI(int score)
		{
			_scoreText.text = $"{_beforeText}{score}{_afterText}";
		}
	}
}
