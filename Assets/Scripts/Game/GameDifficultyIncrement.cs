using System;
using UnityEngine;

namespace Biweekly
{
	[Serializable]
	public sealed class GameDifficultyIncrement
	{
		[Min(0f)]
		public float minSpawnCooldown = 0f;
		[Min(0f)]
		public float maxSpawnCooldown = 0f;
		[Min(0f)]
		public float timeUntilNextIncrement = 0f;
	}
}