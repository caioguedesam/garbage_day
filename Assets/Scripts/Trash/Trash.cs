using System;
using System.Collections;
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
		private TrashMovement _movement = null;

		public TrashMovement Movement => _movement;

		private void Awake()
		{
			_movement = GetComponent<TrashMovement>();
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Ground"))
			{
				Drop();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Trash Pickup Trigger"))
			{
				HitPlayer();
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.CompareTag("Trash Disposal Destination") && _movement.IsFalling)
			{
				Kill();
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