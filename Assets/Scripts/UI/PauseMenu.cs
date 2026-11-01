using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class PauseMenu : MonoBehaviour {
        private bool _isPaused = false;

        private InputAction _pauseAction;

        private void Awake() {
            _pauseAction = InputSystem.actions.FindAction("Player/Pause");
        }

        private void OnEnable() {
            _pauseAction.Enable();
            _pauseAction.performed += OnPause;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable() {
            _pauseAction.performed -= OnPause;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private void OnPause(InputAction.CallbackContext context) {
            if (_isPaused) {
                UIOptions.Close();
            } else {
                Pause();
            }
        }

        private void OnSceneUnloaded(Scene scene) {
            if (scene.name == UIOptions.SceneName) {
                Resume();
            }
        }

        private void Resume() {
            Time.timeScale = 1f;
            _isPaused = false;
        }

        private void Pause() {
            UIOptions.Open();
            Time.timeScale = 0f;
            _isPaused = true;
        }
    }
}