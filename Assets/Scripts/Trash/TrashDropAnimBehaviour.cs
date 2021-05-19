using UnityEngine;

namespace Biweekly
{
	public sealed class TrashDropAnimBehaviour : StateMachineBehaviour
	{
		public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			Trash trash = animator.gameObject.GetComponentInParent<Trash>();
			trash.Kill();
		}
	}
}
