using System;
using UnityEngine;
using UnityEngine.Events;

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
		[SerializeField]
		private ParticleSystem _dustParticles = null;
		[SerializeField]
		private Transform _dustPositionLeft = null;
		[SerializeField]
		private Transform _dustPositionRight = null;
		private PlayerInputController _input = null;

		[Header("Animation Control")]
		[SerializeField]
		private string _animatorFlipParam = "";
		[SerializeField]
		private string _animatorSpeedParam = "";
		[SerializeField, Min(0f)]
		private float _wheelAnimationModifier = 1f;
		[SerializeField, Min(0f)]
		private float _minDustEmission = 1f;
		[SerializeField, Min(0f)]
		private float _maxDustEmission = 1f;

		[Header("Rendering Variables")]
		[SerializeField]
		private int _topWheelOrder = 0;
		[SerializeField]
		private int _bottomWheelOrder = 0;

		private bool _lastFrameFacingRight = true;
		
		[SerializeField]
		private UnityEvent _onCollectedTrash = null;
		[SerializeField]
		private UnityEvent _onDisposedTrash = null;

		private void Awake()
		{
			_input = GetComponentInParent<PlayerInputController>();
		}

		private void Update()
		{
			UpdateFacingState();
			UpdateWheelAnimators();
			UpdateDustParticles();
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
			FlipDustParticle(right);
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

		private void UpdateDustParticles()
		{
			float dustEmission = 0f;
			float t = Mathf.Abs(_movement.NormalizedMoveSpeed);
			if (t > 0)
			{
				dustEmission =
					Mathf.Lerp(_minDustEmission, _maxDustEmission, t);
			}
			ParticleSystem.EmissionModule emission = _dustParticles.emission;
			emission.rateOverTime = dustEmission;
		}

		private void FlipDustParticle(bool right)
		{
			_dustParticles.transform.localPosition = right ? _dustPositionLeft.localPosition : _dustPositionRight.localPosition;
			_dustParticles.transform.eulerAngles = right ? new Vector3(0f, 0f, 0f) : new Vector3(0f, 180f, 0f);
		}

		public void OnCollect()
		{
			_onCollectedTrash.Invoke();
		}

		public void OnDispose()
		{
			_onDisposedTrash.Invoke();
		}
	}
}
