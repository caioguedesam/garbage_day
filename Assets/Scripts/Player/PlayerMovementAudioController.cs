using System;
using UnityEngine;

namespace Biweekly
{
	public sealed class PlayerMovementAudioController : MonoBehaviour
	{
		[SerializeField]
		private PlayerSidewaysMovement _movement = null;
		private AudioSource _source = null;
		private float _initialVolume = 0f;

		private void Awake()
		{
			_source = GetComponent<AudioSource>();
			_initialVolume = _source.volume;
		}

		private void Update()
		{
			_source.volume = Mathf.Abs(_movement.NormalizedMoveSpeed) * _initialVolume;
		}
	}
}