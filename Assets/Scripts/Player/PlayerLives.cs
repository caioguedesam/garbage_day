using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class PlayerLives : MonoBehaviour
	{
		[SerializeField]
		private LivesData _livesData = null;
		[SerializeField]
		private UnityEvent _onDamaged = null;

		private void Awake()
		{
			_livesData.ResetCurrentLives();
		}

		public void TakeDamage()
		{
			if (_livesData.Dead) return;

			_livesData.ReduceLife();
			_onDamaged.Invoke();
		}
	}
}