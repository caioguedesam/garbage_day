using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class UILifeIcon : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _onLost = null;

		public bool IsLost { get; private set; }

		public void LoseIcon()
		{
			IsLost = true;
			_onLost.Invoke();
		}
	}
}