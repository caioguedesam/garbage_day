using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class PauseController : MonoBehaviour
	{
		[SerializeField]
		private PlayerInputController _input = null;

		[SerializeField]
		private UnityEvent _onPause = null;
		[SerializeField]
		private UnityEvent _onUnpause = null;

		private bool _isPaused = false;

		private void Update()
		{
			if (_input.PauseInput)
			{
				if(!_isPaused) Pause();
				else Unpause();
			}
		}

		private void Pause()
		{
			Time.timeScale = 0f;
			_isPaused = true;
			_onPause.Invoke();
		}

		private void Unpause()
		{
			Time.timeScale = 1f;
			_isPaused = false;
			_onUnpause.Invoke();
		}
	}
}