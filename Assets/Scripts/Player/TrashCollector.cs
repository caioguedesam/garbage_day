using UnityEngine;

namespace Biweekly
{
	public sealed class TrashCollector : MonoBehaviour
	{
		// References
		[SerializeField]
		private Transform _trashParent = null;
		[SerializeField]
		private CarryWeightList _carryWeightList = null;
		
		// Collection Variables
		[SerializeField, Min(0)]
		private int _carryCapacity = 1;
		private int _carriedAmount = 0;

		public float CarryWeightModifier => _carryWeightList.GetWeightModifier(_carriedAmount);

		public void CollectTrash(GameObject trashObj)
		{
			Trash trash = trashObj.GetComponent<Trash>();
			if (trash == null) return;

			if (_carriedAmount >= _carryCapacity) return;
			StashTrash(trash);
			_carriedAmount++;
		}

		private void StashTrash(Trash trash)
		{
			trash.transform.parent = _trashParent;
			trash.gameObject.SetActive(false);
		}
	}
}
