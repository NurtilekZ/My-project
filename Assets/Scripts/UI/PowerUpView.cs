using System.Collections;
using PowerUps;
using TMPro;
using UnityEngine;

namespace UI
{
	public class PowerUpView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _effectText;

		// Start is called before the first frame update
		void Start()
		{
			Player.Player.Instance.OnApplyPowerUp += ShowEffectText;
		}

		private void ShowEffectText(PowerUp powerUp)
		{
			StartCoroutine(CountEffectTimer(powerUp.EffectTime));
		}

		private IEnumerator CountEffectTimer(float effectTime)
		{
			while(effectTime > 0)
			{
				_effectText.text = $"{--effectTime}";
				yield return new WaitForSeconds(1);
			}
		}
	}
}
