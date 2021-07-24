using Assets.Scripts;
using System;
using UnityEngine;

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

	public event Action<PowerUp> OnPowerUpPicked;
    // Update is called once per frame
    void Update()
    {
        
    }
}
