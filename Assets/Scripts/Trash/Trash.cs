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
		
		// References
		[SerializeField]
		private Rigidbody2D _body = null;

		public Rigidbody2D Body => _body;

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