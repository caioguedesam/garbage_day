using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Biweekly
{
	public sealed class TrashMovement : MonoBehaviour
	{
		// References
		private Rigidbody2D _body = null;
		
		[Header("Jump Variables")]
		[SerializeField, Min(0f)]
		private float _initialJumpDistanceRange = 0f;
		[SerializeField, Min(0f)]
		private float _initialJumpHeight = 0f;
		[SerializeField, Min(0f)]
		private float _initialJumpTime = 0f;
		[SerializeField]
		private float _fallTime = 0f;
		[SerializeField]
		private LayerMask _groundLayers = 0;

		private Vector2 _gravity = Vector2.zero;
		private bool _isJumping = false;

		public bool IsFalling => _body.velocity.y < 0f;

		private void Awake()
		{
			_body = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			InitialJump();
		}

		private void FixedUpdate()
		{
			_body.velocity += Time.fixedDeltaTime * _gravity;
		}

		public void Jump(float height, float time, float dist)
		{
			_gravity = GetGravity(height, time);
			float velX = dist / time;
			float velY = 2 * height / time;
			_body.velocity = new Vector2(velX, velY);
		}

		private void InitialJump()
		{
			if (!_isJumping) StartCoroutine(InitialJumpRoutine());
		}

		private IEnumerator InitialJumpRoutine()
		{
			// Jump
			_isJumping = true;
			float dist = Random.Range(-_initialJumpDistanceRange, _initialJumpDistanceRange);
			float velX = dist / _initialJumpTime;
			float velY = 2 * _initialJumpHeight / _initialJumpTime;
			_gravity = GetGravity(_initialJumpHeight, _initialJumpTime);
			_body.velocity = new Vector2(velX, velY);

			yield return new WaitUntil(() => IsFalling);
			
			// Fall
			RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f, _groundLayers);
			if (hit.collider != null)
			{
				dist = hit.distance;
				_gravity = GetGravity(dist, _fallTime);
			}
			
			_isJumping = false;
		}

		private static Vector2 GetGravity(float height, float time)
		{
			float y = (-2 * height) / Mathf.Pow(time, 2);
			return new Vector2(0f, y);
		}
	}
}
