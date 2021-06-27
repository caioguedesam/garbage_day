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
		private UnityEvent _onStartedSpawn = null;
		[SerializeField]
		private UnityEvent _onSpawnedTrash = null;
		[SerializeField]
		private UnityEvent _onFinishedSpawn = null;
		
		// Spawn Variables
		private bool _isSpawning = false;

		public bool IsSpawning => _isSpawning;

		public void Spawn()
		{
			if (_isSpawning) return;
			
			_isSpawning = true;
			_onStartedSpawn.Invoke();
		}

		public void ThrowTrash()
		{
			if (!_isSpawning) return;
			
			Instantiate(_trashPrefabs.GetRandomTrash(), transform);
			_onSpawnedTrash.Invoke();
		}

		public void FinishSpawn()
		{
			if (!_isSpawning) return;
			
			_onFinishedSpawn.Invoke();
			_isSpawning = false;
		}
	}
}