using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "CarryWeightList", menuName = "Biweekly/Week 1/Carry Weight Percentages", order = 0)]
	public sealed class CarryWeightList : ScriptableObject
	{
		[SerializeField, Range(0f, 1f)]
		private List<float> percentages = new List<float>();

		public float GetWeightModifier(int carriedAmount)
		{
			if (carriedAmount <= 0) return 1f;
			if (carriedAmount >= percentages.Count) return percentages[percentages.Count - 1];
			int index = carriedAmount - 1;
			return percentages[index];
		}
	}
}