using UnityEngine;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class UIStart : MonoBehaviour {
        public void PlayGame() {
            SceneManager.LoadScene("Level1");
        }

        public void OpenOptions() {
            UIOptions.Open();
        }

        public void QuitGame() {
            Application.Quit();
        }
    }

}

