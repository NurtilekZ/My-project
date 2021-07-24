using UnityEngine;

namespace Management.ObjectPooling
{
    public class PoolingDisableTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PoolingObject>(out var poolingObject))
            {
                poolingObject.Disable();
            }
        }
    }
}
