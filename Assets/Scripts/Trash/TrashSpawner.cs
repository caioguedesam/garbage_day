using System.Collections;
using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawner : MonoBehaviour
	{
		// References
		[SerializeField]
		private Trash _trashPrefab = null;

		// Spawn Variables
		private float _timeToSpawn = 5f;
		private bool _spawning = false;

		private void Start()
		{
			StartCoroutine(SpawnRoutine());
		}

		private IEnumerator SpawnRoutine()
		{
			if(_spawning) yield break;
			_spawning = true;

			while (_spawning)
			{
				float elapsedTime = 0f;
				while (elapsedTime < _timeToSpawn)
				{
					yield return new WaitForEndOfFrame();
					elapsedTime += Time.deltaTime;
				}
				Spawn();
			}
		}

		private void Spawn()
		{
			Instantiate(_trashPrefab, transform);
		}
	}
}