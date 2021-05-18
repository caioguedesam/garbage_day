using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawnerController : MonoBehaviour
	{
		// References
		[SerializeField]
		private GameDifficultyController _difficultyController = null;

		// Spawner control variables
		private List<TrashSpawner> _spawners = new List<TrashSpawner>();
		private GameDifficultyIncrement DifficultyIncrement => _difficultyController.CurrentDifficultyIncrement;
		private bool _active = false;

		private void Awake()
		{
			_spawners = new List<TrashSpawner>(GetComponentsInChildren<TrashSpawner>());
			_active = true;
		}

		private void Start()
		{
			StartCoroutine(SpawnRoutine());
		}

		private IEnumerator SpawnRoutine()
		{
			while (_active)
			{
				float spawnCooldown = Random.Range(DifficultyIncrement.minSpawnCooldown,
					DifficultyIncrement.maxSpawnCooldown);
				Debug.Log($"Waiting {spawnCooldown} seconds for next spawn");
				yield return new WaitForSeconds(spawnCooldown);
				Spawn();
			}
		}

		private void Spawn()
		{
			TrashSpawner selectedSpawner = _spawners[Random.Range(0, _spawners.Count)];
			selectedSpawner.Spawn();
		}
	}
}
