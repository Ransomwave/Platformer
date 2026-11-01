using deltaformer;
using UnityEngine;

namespace deltaformer {
    public class DeadZoneHandler : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent<ILivingEntity>(out var livingEntity)) {
                livingEntity.Kill();
            }
        }
    }
}
