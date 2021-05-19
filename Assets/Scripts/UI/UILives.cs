using System;
using System.Collections.Generic;
using UnityEngine;

namespace Biweekly
{
	public sealed class UILives : MonoBehaviour
	{
		[SerializeField]
		private LivesData _livesData = null;
		[SerializeField]
		private UILifeIcon _lifeIconPrefab = null;

		private List<UILifeIcon> _lifeIcons = new List<UILifeIcon>();

		private void Awake()
		{
			Setup();
		}

		private void Setup()
		{
			if(_lifeIcons.Count > 0) ClearIcons();
			
			for (int i = 0; i < _livesData.MaxLives; i++)
			{
				UILifeIcon lifeIcon = Instantiate(_lifeIconPrefab, transform);
				_lifeIcons.Add(lifeIcon);
			}
		}
		
		public void UpdateLifeIcons()
		{
			int livesRemaining = _livesData.CurrentLives;
			for (int i = _lifeIcons.Count - 1; i >= livesRemaining; i--)
			{
				if (!_lifeIcons[i].IsLost)
				{
					_lifeIcons[i].LoseIcon();
				}
			}
		}

		private void ClearIcons()
		{
			for (int i = _lifeIcons.Count - 1; i >= 0; i--)
			{
				Destroy(_lifeIcons[i]);
				_lifeIcons.RemoveAt(i);
			}
		}
	}
}