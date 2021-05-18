using UnityEngine;
using UnityEngine.InputSystem;

namespace Biweekly
{
	public sealed class PlayerInputController : MonoBehaviour, PlayerActions.IGameplayActions
	{
		// References
		private PlayerActions _actions = null;
		
		// Input Variables
		private float _horizontalInput = 0f;
		public float HorizontalInput => _horizontalInput;

		private void OnEnable()
		{
			if (_actions == null)
			{
				_actions = new PlayerActions();
				_actions.Gameplay.SetCallbacks(this);
			}
			
			_actions.Gameplay.Enable();
		}

		public void OnMovement(InputAction.CallbackContext context)
		{
			_horizontalInput = context.performed ? context.ReadValue<float>() : 0f;
		}
	}
}