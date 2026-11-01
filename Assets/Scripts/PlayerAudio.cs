using UnityEngine;

namespace deltaformer {
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour {
        [SerializeField] private AudioClip _attackClip;
        [SerializeField] private AudioClip _hurtClip;
        [SerializeField] private AudioClip _jumpClip;
        [SerializeField] private AudioClip _deathClip;

        private AudioSource _audioSource;
        private PlayerController _playerController;

        private void Awake() {
            _audioSource = GetComponent<AudioSource>();
            _playerController = GetComponent<PlayerController>();
            _playerController.OnPlayerAttack += () => _audioSource.PlayOneShot(_attackClip);
            _playerController.OnPlayerDamaged += () => _audioSource.PlayOneShot(_hurtClip);
            _playerController.OnPlayerJump += () => _audioSource.PlayOneShot(_jumpClip);
            _playerController.OnPlayerDeath += () => _audioSource.PlayOneShot(_deathClip);
        }
    }

}