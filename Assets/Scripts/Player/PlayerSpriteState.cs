using System;
using UnityEngine;

namespace Biweekly
{
	public sealed class PlayerSpriteState : MonoBehaviour
	{
		[Header("Player Sprite Renderers")]
		[SerializeField]
		private SpriteRenderer _bodySprite = null;
		[SerializeField]
		private SpriteRenderer _wheelLeftSprite = null;
		[SerializeField]
		private SpriteRenderer _wheelRightSprite = null;
		
		[Header("References")]
		[SerializeField]
		private PlayerSidewaysMovement _movement = null;
		[SerializeField]
		private Animator _wheelLeftAnimator = null;
		[SerializeField]
		private Animator _wheelRightAnimator = null;
		private PlayerInputController _input = null;

		[Header("Animation Control")]
		[SerializeField]
		private string _animatorFlipParam = "";
		[SerializeField]
		private string _animatorSpeedParam = "";
		[SerializeField, Min(0f)]
		private float _wheelAnimationModifier = 1f;

		[Header("Rendering Variables")]
		[SerializeField]
		private int _topWheelOrder = 0;
		[SerializeField]
		private int _bottomWheelOrder = 0;

		private bool _lastFrameFacingRight = true;

		// TODO: Add on collect events with animator

		private void Awake()
		{
			_input = GetComponentInParent<PlayerInputController>();
		}

		private void Update()
		{
			UpdateFacingState();
			UpdateWheelAnimators();
		}

		private void UpdateFacingState()
		{
			if (_lastFrameFacingRight && _input.HorizontalInput < 0)
			{
				Flip(false);
				_lastFrameFacingRight = false;
			}
			else if (!_lastFrameFacingRight && _input.HorizontalInput > 0)
			{
				Flip(true);
				_lastFrameFacingRight = true;
			}
		}

		private void Flip(bool right)
		{
			_bodySprite.flipX = !right;
			_wheelLeftSprite.flipX = !right;
			_wheelRightSprite.flipX = !right;
			if (right)
			{
				_wheelLeftSprite.sortingOrder = _topWheelOrder;
				_wheelRightSprite.sortingOrder = _bottomWheelOrder;
			}
			else
			{
				_wheelLeftSprite.sortingOrder = _bottomWheelOrder;
				_wheelRightSprite.sortingOrder = _topWheelOrder;
			}
		}

		private void UpdateWheelAnimators()
		{
			float speed = _movement.MoveSpeed * _wheelAnimationModifier;
			UpdateWheelAnimator(_wheelLeftAnimator, speed);
			UpdateWheelAnimator(_wheelRightAnimator, speed);
		}

		private void UpdateWheelAnimator(Animator animator, float speed)
		{
			animator.SetFloat(_animatorSpeedParam, speed);
			animator.SetBool(_animatorFlipParam, !_lastFrameFacingRight);
		}
	}
}
