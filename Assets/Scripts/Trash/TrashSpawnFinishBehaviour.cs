using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawnFinishBehaviour : StateMachineBehaviour
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			TrashSpawner spawner = animator.gameObject.GetComponent<TrashSpawner>();
			spawner.FinishSpawn();
		}
	}
}