using UnityEngine;

namespace deltaformer {
    public class BananaAudio : MonoBehaviour {

        private AudioSource _audioSource;
        private GameManager _gameManager;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _gameManager = FindAnyObjectByType<GameManager>();
            _gameManager.OnBananaCountIncremented += () => _audioSource.PlayOneShot(_audioSource.clip);
        }
    }

}