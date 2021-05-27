using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Biweekly
{
	public sealed class UICarryCapacity : MonoBehaviour
	{
		[SerializeField]
		private Image _carryImage = null;
		[SerializeField]
		private List<Sprite> _spriteList = new List<Sprite>();
		[SerializeField]
		private GameObject _fullTextObject = null;

		private int _carried = 0;

		[Header("Events")]
		[SerializeField]
		private UnityEvent _onIncreased = null;
		[SerializeField]
		private UnityEvent _onDecreased = null;

		public void Increase()
		{
			_carried++;
			if (_carried >= _spriteList.Count) _carried = _spriteList.Count - 1;
			UpdateSprite();
			_onIncreased.Invoke();
		}

		public void Decrease()
		{
			_carried--;
			if (_carried < 0) _carried = 0;
			UpdateSprite();
			_onDecreased.Invoke();
		}

		private void UpdateSprite()
		{
			_carryImage.sprite = _spriteList[_carried];
			_fullTextObject.SetActive(_carried == _spriteList.Count - 1);
		}
	}
}
