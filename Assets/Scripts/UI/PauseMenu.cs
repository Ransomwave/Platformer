using UnityEngine;
using UnityEngine.InputSystem;

namespace deltaformer {
    public class PauseMenu : MonoBehaviour {
        [Header("UI Pause Panel")]
        [SerializeField] private GameObject _pauseMenuUI;

        private bool _isPaused = false;

        private void Start() {
            _pauseMenuUI.SetActive(false);
        }

        void Update() {
            if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame) {
                if (_isPaused) {
                    Resume();
                } else {
                    Pause();
                }
            }
        }

        public void Resume() {
            if (_pauseMenuUI != null) {
                _pauseMenuUI.SetActive(false);
            }

            Time.timeScale = 1f;
            _isPaused = false;
        }

        void Pause() {
            if (_pauseMenuUI != null) {
                _pauseMenuUI.SetActive(true);
            }

            Time.timeScale = 0f;
            _isPaused = true;
        }
    }
}