using UnityEngine;

namespace Biweekly
{
	public sealed class PlayerSidewaysMovement : MonoBehaviour
	{
		// References
		private Rigidbody2D _body = null;
		private PlayerInputController _input = null;
		private TrashCollector _trashCollector = null;

		[Header("Movement Variables")]
		[SerializeField]
		private float _startMoveSpeed = 1f;
		[SerializeField]
		private float _maximumMoveSpeed = 0f;
		[SerializeField, Min(0f)]
		private float _moveAccel = 1f;
		[SerializeField, Min(0f)]
		private float _breakAccel = 1f;

		private float _moveSpeed = 0f;
		private bool _onMovement = false;

		public float MoveSpeed => _moveSpeed * WeightModifier;
		private float WeightModifier => _trashCollector.CarryWeightModifier;

		private void Awake()
		{
			_body = GetComponent<Rigidbody2D>();
			_input = GetComponent<PlayerInputController>();
			_trashCollector = GetComponent<TrashCollector>();
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			_moveSpeed = CalculateMoveSpeed();
			_body.velocity = new Vector2(_moveSpeed * WeightModifier, _body.velocity.y);
		}

		private float CalculateMoveSpeed()
		{
			return _input.HorizontalInput != 0 ? CalculateAccelerationMoveSpeed() : CalculateBreakMoveSpeed();
		}

		private float CalculateAccelerationMoveSpeed()
		{
			float speed = _moveSpeed;
			// Set start speed for beginning of movement
			if (!_onMovement)
			{
				_onMovement = true;
				speed = _input.HorizontalInput > 0 ? 
					Mathf.Max(speed, _startMoveSpeed) : Mathf.Min(speed, -_startMoveSpeed);
			}
			speed += _input.HorizontalInput * _moveAccel * Time.fixedDeltaTime;
			return Mathf.Clamp(speed, -_maximumMoveSpeed, _maximumMoveSpeed);
		}

		private float CalculateBreakMoveSpeed()
		{
			float speed = _moveSpeed;
			// Ending movement
			if (speed < 1f && speed > -1f)
			{
				_onMovement = false;
				return 0f;
			}
			float breakAccel = speed < 0 ? _breakAccel : -_breakAccel;
			return speed + breakAccel * Time.fixedDeltaTime;
		}
	}
}
