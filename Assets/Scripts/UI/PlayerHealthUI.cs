using UnityEngine;
using UnityEngine.UI;

namespace deltaformer {
    public class PlayerHealthUI : MonoBehaviour {
        [Header("Array of hearts")]
        [SerializeField] private Image[] _hearts;

        private PlayerController _playerController;

        private void Start() {
            _playerController = FindAnyObjectByType<PlayerController>();

            if (_playerController != null) {
                _playerController.OnPlayerDamaged += UpdateHeartsUI;
                _playerController.OnPlayerDeath += UpdateHeartsUI;

                UpdateHeartsUI();
            } else {
                Debug.LogWarning("PlayerHealthUI no encontró ningún PlayerController en la escena.");
            }
        }

        private void OnDestroy() {
            if (_playerController != null) {
                _playerController.OnPlayerDamaged -= UpdateHeartsUI;
                _playerController.OnPlayerDeath -= UpdateHeartsUI;
            }
        }

        public void UpdateHeartsUI() {
            if (_playerController == null) return;

            int currentHealth = _playerController.HP;

            for (int i = 0; i < _hearts.Length; i++) {
                if (i < currentHealth) {
                    _hearts[i].gameObject.SetActive(true);
                } else {
                    _hearts[i].gameObject.SetActive(false);
                }
            }
        }
    }
}