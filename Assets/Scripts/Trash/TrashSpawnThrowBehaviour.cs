using UnityEngine;

namespace Biweekly
{
	public sealed class TrashSpawnThrowBehaviour : StateMachineBehaviour
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			TrashSpawner spawner = animator.gameObject.GetComponent<TrashSpawner>();
			spawner.ThrowTrash();
		}
	}
}