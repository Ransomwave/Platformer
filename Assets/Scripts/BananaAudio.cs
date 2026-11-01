using UnityEngine;

namespace deltaformer {
    [RequireComponent(typeof(AudioSource))]
    public class BananaAudio : MonoBehaviour {
        [SerializeField] private AudioClip _bananaClip;

        private AudioSource _audioSource;
        private GameManager _gameManager;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _gameManager = GetComponent<GameManager>();
            _gameManager.OnBananaAudio += () => _audioSource.PlayOneShot(_bananaClip);
        }
    }

}