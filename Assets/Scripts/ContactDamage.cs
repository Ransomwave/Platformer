using UnityEngine;

namespace deltaformer {
    public class ContactDamage : MonoBehaviour {
        [SerializeField] private int _damage = 1;

        // stay instead of Enter so the player is hit again once invincibility wears off
        private void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("Player") && other.TryGetComponent<ILivingEntity>(out var livingEntity)) {
                livingEntity.TakeDamage(_damage);
            }
        }
    }
}
