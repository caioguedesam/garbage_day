using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "LivesData", menuName = "Biweekly/Week 1/Lives Data", order = 0)]
	public sealed class LivesData : ScriptableObject
	{
		[Header("Lives Variables")]
		[SerializeField, Min(1)]
		private int _maxLives = 1;
		private int _currentLives = 1;

		private bool _dead = false;

		public int MaxLives => _maxLives;
		public int CurrentLives => _currentLives;
		public bool Dead => _dead;
		
		[Header("Events")]
		[SerializeField]
		private UnityEvent _onDeath = null;

		public void ResetCurrentLives()
		{
			_currentLives = _maxLives;
			_dead = false;
		}

		public void ReduceLife()
		{
			if (_currentLives <= 0) return;
			_currentLives--;
			if (_currentLives != 0) return;
			
			_dead = true;
			_onDeath.Invoke();
		}
	}
}