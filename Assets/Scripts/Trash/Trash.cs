using Common;
using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class Trash : MonoBehaviour
	{
		[SerializeField]
		private GameObjectUnityEvent _onPlayerCollision = null;
		[SerializeField]
		private UnityEvent _onDrop = null;

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Ground"))
			{
				Drop();
			}
			else if (other.gameObject.CompareTag("Player"))
			{
				HitPlayer();
			}
		}

		private void HitPlayer()
		{
			_onPlayerCollision.Invoke(gameObject);
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