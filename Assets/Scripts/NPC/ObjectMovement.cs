using PowerUps;
using UnityEngine;

namespace NPC
{
	public class ObjectMovement : MonoBehaviour
	{
		[SerializeField] private float _speed;
		[SerializeField] private Vector2 _direction;

		private float _defaultSpeed;

		private void Start()
		{
			_defaultSpeed = _speed;
			SpeedPowerUp.OnSpeedPowerUpApplied += SetSpeed;
			SpeedPowerUp.OnSpeedPowerUpStopped += ResetSpeed;
		}

		private void ResetSpeed()
		{
			_speed = _defaultSpeed;
		}

		public void SetSpeed(float newSpeed)
		{
			_speed = newSpeed;
		}

		void Update()
		{
			transform.Translate(_direction * _speed * Time.deltaTime);
		}
	}
}
