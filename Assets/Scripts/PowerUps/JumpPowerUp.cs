using Player;
using UnityEngine;

namespace PowerUps
{
	public class JumpPowerUp : PowerUp
	{
		[SerializeField] private float _jumpForce;

		public override void Apply(Player.Player player)
		{
			base.Apply(player);
			player.GetComponent<PlayerMovement>().JumpForce = _jumpForce;
		}

		public override void Stop(Player.Player player)
		{
			player.GetComponent<PlayerMovement>().ResetJumpForce();
		}
	}
}