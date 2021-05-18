using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawner : MonoBehaviour
	{
		// References
		[SerializeField]
		private TrashPrefabList _trashPrefabs = null;

		public void Spawn()
		{
			Instantiate(_trashPrefabs.GetRandomTrash(), transform);
		}
	}
}