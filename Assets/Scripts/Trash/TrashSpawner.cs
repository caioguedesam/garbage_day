using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class TrashSpawner : MonoBehaviour
	{
		// References
		[SerializeField]
		private TrashPrefabList _trashPrefabs = null;
		[SerializeField]
		private UnityEvent _onSpawn = null;
		[SerializeField]
		private UnityEvent _onFinishedSpawn = null;
		
		// Spawn Variables
		private bool _isSpawning = false;

		public bool IsSpawning => _isSpawning;

		public void Spawn()
		{
			if (_isSpawning) return;
			
			_isSpawning = true;
			_onSpawn.Invoke();
		}

		public void FinishSpawn()
		{
			if (!_isSpawning) return;
			
			Instantiate(_trashPrefabs.GetRandomTrash(), transform);
			_onFinishedSpawn.Invoke();
			_isSpawning = false;
		}
	}
}