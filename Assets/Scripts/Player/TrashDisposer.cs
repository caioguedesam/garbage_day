using UnityEngine;
using Random = UnityEngine.Random;

namespace Biweekly
{
	public sealed class TrashDisposer : MonoBehaviour
	{
		// References
		[SerializeField]
		private Transform _disposalOrigin = null;
		[SerializeField]
		private Transform _disposalPoint = null;
		private PlayerInputController _input = null;
		private TrashCollector _trashCollector = null;
		
		// Disposal Control Variables
		[SerializeField, Range(0f, 10f)]
		private float _minDisposeJumpHeight = 0f;
		[SerializeField, Range(0f, 10f)]
		private float _maxDisposeJumpHeight = 0f;
		[SerializeField, Range(0f, 2f)]
		private float _disposeJumpTime = 0f;
		[SerializeField]
		private bool _canDispose = false;

		private void Awake()
		{
			_input = GetComponent<PlayerInputController>();
			_trashCollector = GetComponent<TrashCollector>();
		}

		private void Update()
		{
			if (_input.DisposeInput)
			{
				Dispose();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.CompareTag("Trash Disposal Area"))
			{
				AllowDispose(true);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.CompareTag("Trash Disposal Area"))
			{
				AllowDispose(false);
			}
		}

		private void AllowDispose(bool value)
		{
			_canDispose = value;
		}

		private void Dispose()
		{
			if (!_canDispose || _trashCollector.IsEmpty) return;
			
			Trash disposedTrash = _trashCollector.PopTrash();
			if (disposedTrash == null) return;

			Vector2 startPos = _disposalOrigin.position;
			disposedTrash.transform.position = startPos;
			disposedTrash.gameObject.SetActive(true);
			
			float jumpHeight = Random.Range(_minDisposeJumpHeight, _maxDisposeJumpHeight);
			float jumpDist = ((Vector2)_disposalPoint.position - startPos).x;
			
			disposedTrash.Movement.Jump(jumpHeight, _disposeJumpTime/2f, jumpDist/2);
		}
	}
}