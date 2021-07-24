using UnityEngine;

namespace Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float _jumpForce;
		[SerializeField] private float _gravity;
		[SerializeField] private bool _isGrounded;

		private Vector3 defaulPosition;
		private float defaulJumpForce;
		private float runtimeJumpForce;

		public float JumpForce { get => _jumpForce; set => _jumpForce = value; }

		internal void ResetJumpForce()
		{
			JumpForce = defaulJumpForce;
		}

		private void Start()
		{
			defaulPosition = transform.position;
			defaulJumpForce = JumpForce;
		}

		// Update is called once per frame
		void Update()
		{
			if (!_isGrounded)
			{
				runtimeJumpForce -= _gravity;
				transform.Translate(Vector3.up * runtimeJumpForce * Time.deltaTime);
			}

			if (transform.position.y <= defaulPosition.y)
			{
				_isGrounded = true;
				transform.position = defaulPosition;
			}

			if (Input.GetKeyDown(KeyCode.Mouse0) && _isGrounded)
			{
				runtimeJumpForce = JumpForce;
				_isGrounded = false;
			}
		}
	}
}
