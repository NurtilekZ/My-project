using System.Collections;
using System.Collections.Generic;
using PowerUps;
using UnityEngine;

namespace Management.ObjectPooling
{
	public class PoolingSystem : MonoBehaviour
	{
		[SerializeField] private List<PoolingObject> _objectsToPool = new List<PoolingObject>();
		[SerializeField] protected Vector2 _minMaxTimeInterval;
		[SerializeField] private float _instanceCount;
		[SerializeField] protected float _startSpeed;
		private float _defaultSpeed;

		protected List<PoolingObject> _poolingList = new List<PoolingObject>();
		protected IEnumerator Spawning;

		private void PreInstantiateObjects()
		{
			for(int i = 0; i < _instanceCount; i++)
			{
				foreach(PoolingObject poolingObj in _objectsToPool)
				{
					PoolingObject obj = Instantiate(poolingObj, transform);
					obj.gameObject.SetActive(false);
					obj.poolingSystem = this;
					_poolingList.Add(obj);
				}
			}
		}

		// Start is called before the first frame update
		protected virtual void Start()
		{
			_defaultSpeed = _startSpeed;
			SpeedPowerUp.OnSpeedPowerUpApplied += SetSpeed;
			SpeedPowerUp.OnSpeedPowerUpStopped += ResetSpeed;
			Spawning = Spawn();
			PreInstantiateObjects();	
			StartSpawning();
		}

		private void ResetSpeed()
		{
			_startSpeed = _defaultSpeed;
		}

		private void SetSpeed(float newSpeed)
		{
			_startSpeed = newSpeed;
		}

		protected virtual void StartSpawning()
		{
			StartCoroutine(Spawning);
		}

		protected virtual IEnumerator Spawn()
		{
			while (true)
			{
				int randomIndex = Random.Range(0, _poolingList.Count);
				if (!_poolingList[randomIndex].gameObject.activeSelf)
				{
					_poolingList[randomIndex].Enable(_startSpeed);
					_poolingList.RemoveAt(randomIndex);
				}
				yield return new WaitForSeconds(UnityEngine.Random.Range(_minMaxTimeInterval.x, _minMaxTimeInterval.y));
			}
		}

		public void Pool(PoolingObject poolingObject)
		{
			_poolingList.Add(poolingObject);
		}
	}
}
