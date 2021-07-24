using System;
using UnityEngine;

namespace PowerUps
{
	public class SpeedPowerUp : PowerUp
	{
		public static event Action<float> OnSpeedPowerUpApplied;
		public static event Action OnSpeedPowerUpStopped;

		[SerializeField] private float _speed;

		public override void Apply(Player.Player player)
		{
			base.Apply(player);
			OnSpeedPowerUpApplied?.Invoke(_speed);
		}

		public override void Stop(Player.Player player)
		{
			OnSpeedPowerUpStopped?.Invoke();
		}

		private void OnDestroy()
		{
			if(OnSpeedPowerUpApplied != null)
			{
				OnSpeedPowerUpApplied = null;
			}
		}
	}
}