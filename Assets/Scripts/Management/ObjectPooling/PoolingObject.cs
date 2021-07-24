using NPC;
using UnityEngine;

namespace Management.ObjectPooling
{
    public class PoolingObject : MonoBehaviour
    {
        public PoolingSystem poolingSystem;
        public void Enable(float startSpeed = default)
        {
            gameObject.SetActive(true);
            if (startSpeed != default & TryGetComponent<ObjectMovement>(out var movement))
            {
                movement.SetSpeed(startSpeed);             
            }

        }

        public void Disable()
        {
            gameObject.SetActive(false);
            poolingSystem.Pool(this);
        }
    }
}
