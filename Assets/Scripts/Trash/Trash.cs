using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class Trash : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _onDrop = null;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Ground"))
			{
				Drop();
			}
			// TODO: Collide with player
		}

		private void Drop()
		{
			_onDrop.Invoke();
		}

		public void Kill()
		{
			Destroy(gameObject);
		}
	}
}