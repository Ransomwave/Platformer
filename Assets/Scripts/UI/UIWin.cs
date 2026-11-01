using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class UIWin : MonoBehaviour {
        private static readonly WaitForSeconds _waitForSeconds0_05 = new(0.05f);

        private const string MainMenuScene = "UIStart";

        [SerializeField] private TextMeshProUGUI _scoreText;

        private void Awake() {
            Assert.IsNotNull(_scoreText, "ScoreText is not assigned in the UIWin.");
        }

        private IEnumerator ScoreAnimation() {
            var displayedScore = 0;
            var finalScore = GameManager.BananaCount;

            while (displayedScore < finalScore) {
                displayedScore++;
                _scoreText.text = $"SCORE: {displayedScore}";
                yield return _waitForSeconds0_05;
            }
        }

        private void Start() {
            StartCoroutine(ScoreAnimation());
        }

        public void ExitMenu() {
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
