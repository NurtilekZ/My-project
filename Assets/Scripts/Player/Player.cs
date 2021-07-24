using System;
using System.Collections;
using NPC;
using PowerUps;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
	public class Player : MonoBehaviour
	{
		private static Player _instance;

		public static Player Instance
		{
			get
			{
				if (_instance != null)
				{
					_instance = FindObjectOfType<Player>();
				}
				return _instance;
			}
			private set => _instance = value;
		}

		public event Action<PowerUp> OnApplyPowerUp = null;
		public event Action OnStopPowerUp = null;

		private void Awake()
		{
			_instance = this;
		}

		private IEnumerator OnTriggerEnter2D(Collider2D other)
		{
			if (other.TryGetComponent<PowerUp>(out var powerUp))
			{
				powerUp.Apply(this);
				OnApplyPowerUp?.Invoke(powerUp);
				yield return new WaitForSeconds(powerUp.EffectTime);
				powerUp.Stop(this);
				OnStopPowerUp?.Invoke();
			}
			else if (other.TryGetComponent<Obstacle>(out var obstacle))
			{
				SceneManager.LoadScene(0);
			}
		}

		private void OnDestroy()
		{
			OnApplyPowerUp = null;
		}
	}
}