using TMPro;
using UnityEngine;

namespace deltaformer {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class UIScore : MonoBehaviour {
        private TextMeshProUGUI _scoreText;
        private GameManager _gameManager;

        private void Start() {
            _scoreText = GetComponent<TextMeshProUGUI>();
            _gameManager = FindAnyObjectByType<GameManager>();

            if (_gameManager != null) {
                _gameManager.OnBananaCountChanged += UpdateScoreUI;
                UpdateScoreUI(_gameManager.BananaCount);
            } else {
                Debug.LogWarning("UIScore couldn't find a GameManager in the scene.");
            }
        }

        private void OnDestroy() {
            if (_gameManager != null) {
                _gameManager.OnBananaCountChanged -= UpdateScoreUI;
            }
        }

        private void UpdateScoreUI(int bananaCount) {
            _scoreText.text = $"SCORE: {bananaCount}";
        }
    }
}
