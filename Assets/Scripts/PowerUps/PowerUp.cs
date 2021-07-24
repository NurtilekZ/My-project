using Management.ObjectPooling;
using UnityEngine;

namespace PowerUps
{
	public abstract class PowerUp : MonoBehaviour
	{
		[SerializeField] private float _effectTime;

		public float EffectTime { get => _effectTime; private set => _effectTime = value; }

		public virtual void Apply(Player.Player player)
		{
			GetComponent<PoolingObject>().Disable();
		}
		public abstract void Stop(Player.Player player);
	}
}