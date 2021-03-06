using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.Events;

namespace Biweekly
{
	public sealed class TrashCollector : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Transform _trashParent = null;
		[SerializeField]
		private CarryWeightList _carryWeightList = null;
		
		[Header("Collection Variables")]
		[SerializeField, Min(0)]
		private int _carryCapacity = 1;
		[SerializeField]
		private int _collectedTrashLayer = 0;
		private Stack<Trash> _collectedTrash = new Stack<Trash>();

		[Header("Events")]
		[SerializeField]
		private GameObjectUnityEvent _onCollectedTrash = null;

		public float CarryWeightModifier => _carryWeightList.GetWeightModifier(_collectedTrash.Count);
		public bool IsEmpty => _collectedTrash.Count == 0;

		public void CollectTrash(GameObject trashObj)
		{
			Trash trash = trashObj.GetComponent<Trash>();
			if (trash == null) return;

			if (_collectedTrash.Count >= _carryCapacity) return;
			StashTrash(trash);
			_onCollectedTrash.Invoke(trash.gameObject);
		}

		private void StashTrash(Trash trash)
		{
			trash.transform.parent = _trashParent;
			GameObject trashObj = trash.gameObject;
			trashObj.SetActive(false);
			trashObj.layer = _collectedTrashLayer;
			_collectedTrash.Push(trash);
		}

		public Trash PopTrash()
		{
			if (_collectedTrash.Count == 0) return null;
			
			Trash popped = _collectedTrash.Pop();
			popped.transform.SetParent(null);
			
			return popped;
		}
	}
}
