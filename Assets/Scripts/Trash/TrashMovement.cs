using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Biweekly
{
	public sealed class TrashMovement : MonoBehaviour
	{
		// References
		private Rigidbody2D _body = null;
		
		[Header("Random Jump Variables")]
		[SerializeField, Min(0f)]
		private float _minJumpHeight = 0f;
		[SerializeField, Min(0f)]
		private float _maxJumpHeight = 0f;
		[SerializeField, Min(0f)]
		private float _minJumpApexTime = 0f;
		[SerializeField, Min(0f)]
		private float _maxJumpApexTime = 0f;
		[SerializeField, Min(0f)]
		private float _jumpDistanceRange = 0f;

		private Vector2 _gravity = Vector2.zero;

		private void Awake()
		{
			_body = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			RandomJump();
		}

		private void FixedUpdate()
		{
			_body.velocity += Time.fixedDeltaTime * _gravity;
		}

		private void RandomJump()
		{
			float height = Random.Range(_minJumpHeight, _maxJumpHeight);
			float time = Random.Range(_minJumpApexTime, _maxJumpApexTime);
			float dist = Random.Range(-_jumpDistanceRange, _jumpDistanceRange);

			_gravity = GetGravity(height, time);
			float velX = dist / time;
			float velY = 2 * height / time;
			_body.velocity = new Vector2(velX, velY);
		}

		private static Vector2 GetGravity(float height, float time)
		{
			float y = (-2 * height) / Mathf.Pow(time, 2);
			return new Vector2(0f, y);
		}
	}
}
