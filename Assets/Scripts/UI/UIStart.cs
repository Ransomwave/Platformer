using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class UIStart : MonoBehaviour {
        [SerializeField] private AudioMixer _audioMixer;

        public void PlayGame() {
            SceneManager.LoadScene("Level1");
        }

        public void OpenOptions() {
            UIOptions.Open();
        }

        public void QuitGame() {
            Application.Quit();
        }

        private void Awake() {
            Assert.IsNotNull(_audioMixer, "AudioMixer is not assigned in the UIStart.");
        }

        private void Start() {
            GameSettings.Apply(_audioMixer);
        }
    }

}

