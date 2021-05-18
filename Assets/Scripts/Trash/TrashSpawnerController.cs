using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawnerController : MonoBehaviour
	{
		// References
		[SerializeField]
		private SpawnerIncreaseTimes _increaseTimes = null;
		
		// Spawner control variables
		private List<TrashSpawner> _spawners = new List<TrashSpawner>();
		private int _spawnerCount = 0;

		private void Awake()
		{
			_spawners = new List<TrashSpawner>(GetComponentsInChildren<TrashSpawner>(true));
		}

		private void Start()
		{
			StartCoroutine(SpawnerActivationRoutine());
		}

		private IEnumerator SpawnerActivationRoutine()
		{
			Debug.Log("Started spawner activation");
			while (_spawnerCount < _spawners.Count)
			{
				yield return new WaitForSeconds(_increaseTimes[_spawnerCount]);
				ActivateNextSpawner();
			}
		}

		private void ActivateNextSpawner()
		{
			if (_spawnerCount > _spawners.Count - 1) return;
			Debug.Log("Activating next spawner");
			_spawners[_spawnerCount++].gameObject.SetActive(true);
		}
	}
}
