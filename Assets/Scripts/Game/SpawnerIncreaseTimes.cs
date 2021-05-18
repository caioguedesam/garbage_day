using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "SpawnerIncreaseTimes", menuName = "Biweekly/Week 1/Spawner Increase Times", order = 0)]
	public class SpawnerIncreaseTimes : ScriptableObject
	{
		[SerializeField]
		private List<float> _increaseTimes = new List<float>();

		public float this[int index] => _increaseTimes[index];
		public int Count => _increaseTimes.Count;
	}
}