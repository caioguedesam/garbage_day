using System;
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
		private bool _disposeInput = false;
		public float HorizontalInput => _horizontalInput;
		public bool DisposeInput => _disposeInput;

		private void OnEnable()
		{
			if (_actions == null)
			{
				_actions = new PlayerActions();
				_actions.Gameplay.SetCallbacks(this);
			}
			
			_actions.Gameplay.Enable();
		}

		private void LateUpdate()
		{
			if (_disposeInput) _disposeInput = false;
		}

		public void OnMovement(InputAction.CallbackContext context)
		{
			_horizontalInput = context.performed ? context.ReadValue<float>() : 0f;
		}

		public void OnDispose(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				_disposeInput = true;
			}
		}
	}
}