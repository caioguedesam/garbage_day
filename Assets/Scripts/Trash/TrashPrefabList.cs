using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "TrashPrefabList", menuName = "Biweekly/Week 1/Trash Prefab List", order = 0)]
	public class TrashPrefabList : ScriptableObject
	{
		[SerializeField]
		private List<Trash> _trashPrefabs = new List<Trash>();

		public Trash this[int index] => _trashPrefabs[index];

		public Trash GetRandomTrash()
		{
			return _trashPrefabs[Random.Range(0, _trashPrefabs.Count)];
		}
	}
}