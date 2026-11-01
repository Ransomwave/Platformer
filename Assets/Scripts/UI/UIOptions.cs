using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace deltaformer {
    public class UIOptions : MonoBehaviour {
        public const string SceneName = "UIOptions";
        private const string MainMenuScene = "UIStart";

        private const string MasterVolumeKey = "MasterVolume";
        private const string MusicVolumeKey = "MusicVolume";
        private const string SfxVolumeKey = "SfxVolume";
        private const string FullScreenKey = "FullScreen";

        [Header("Audio")]
        [SerializeField] private AudioMixer _audioMixer;

        [Header("UI References")]
        [SerializeField] private Slider _masterSlider;
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Toggle _fullScreenToggle;

        // figure out if the options menu is open by checking if the scene is loaded
        public static bool IsOpen => SceneManager.GetSceneByName(SceneName).isLoaded;

        public static void Open() {
            if (!IsOpen) {
                SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
            }
        }

        public static void Close() {
            if (IsOpen) {
                SceneManager.UnloadSceneAsync(SceneName);
            }
        }

        private void Awake() {
            Assert.IsNotNull(_masterSlider, "MasterSlider is not assigned in the UIOptions.");
            Assert.IsNotNull(_musicSlider, "MusicSlider is not assigned in the UIOptions.");
            Assert.IsNotNull(_sfxSlider, "SfxSlider is not assigned in the UIOptions.");
            Assert.IsNotNull(_fullScreenToggle, "FullScreenToggle is not assigned in the UIOptions.");
        }

        private void Start() {
            _masterSlider.value = PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
            _musicSlider.value = PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
            _sfxSlider.value = PlayerPrefs.GetFloat(SfxVolumeKey, 1f);
            _fullScreenToggle.isOn = PlayerPrefs.GetInt(FullScreenKey, Screen.fullScreen ? 1 : 0) == 1;

            SetMasterVolume(_masterSlider.value);
            SetMusicVolume(_musicSlider.value);
            SetSfxVolume(_sfxSlider.value);
            SetFullScreen(_fullScreenToggle.isOn);
        }

        public void SetMasterVolume(float volume) {
            if (_audioMixer != null) {
                _audioMixer.SetFloat("Master", ToDecibels(volume));
            } else {
                // AudioListener is a "global" audio source that's always present, so we can set its volume directly if the AudioMixer is not assigned.
                AudioListener.volume = volume;
            }
        }

        public void SetMusicVolume(float volume) {
            if (_audioMixer == null) return;
            _audioMixer.SetFloat("Music", ToDecibels(volume));
        }

        public void SetSfxVolume(float volume) {
            if (_audioMixer == null) return;
            _audioMixer.SetFloat("SFX", ToDecibels(volume));

        }

        public void SetFullScreen(bool isFullScreen) {
            Screen.fullScreen = isFullScreen;
        }

        public void SaveConfiguration() {
            PlayerPrefs.SetFloat(MasterVolumeKey, _masterSlider.value);
            PlayerPrefs.SetFloat(MusicVolumeKey, _musicSlider.value);
            PlayerPrefs.SetFloat(SfxVolumeKey, _sfxSlider.value);
            PlayerPrefs.SetInt(FullScreenKey, _fullScreenToggle.isOn ? 1 : 0);
            PlayerPrefs.Save();
        }

        public void ExitMenu() {
            Time.timeScale = 1f;
            SceneManager.LoadScene(MainMenuScene);
        }

        private static float ToDecibels(float volume) {
            return volume > 0f ? Mathf.Log10(volume) * 20f : -80f;
        }
    }
}
