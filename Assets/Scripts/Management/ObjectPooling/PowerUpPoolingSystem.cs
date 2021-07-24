using PowerUps;

namespace Management.ObjectPooling
{
	class PowerUpPoolingSystem : PoolingSystem
	{
		protected override void Start()
		{
			base.Start();
			Player.Player.Instance.OnApplyPowerUp += StopSpawning;
			Player.Player.Instance.OnStopPowerUp += StartSpawning;
		}

		private void StopSpawning(PowerUp powerUp)
		{
			StopCoroutine(Spawning);
		}
	}
}