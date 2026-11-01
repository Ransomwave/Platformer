using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class UIWin : MonoBehaviour {
        private const string MainMenuScene = "UIStart";

        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Awake() {
            Assert.IsNotNull(_scoreText, "ScoreText is not assigned in the UIWin.");
        }

        private void Start() {
            _scoreText.text = $"SCORE: {GameManager.BananaCount}";
        }

        public void ExitMenu() {
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
