using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace deltaformer {
    public class UIOptions : MonoBehaviour {
        [Header("Audio")]
        public AudioMixer audioMixer;

        [Header("UI References")]
        public Slider masterSlider;
        public Slider musicSlider;
        public Slider sfxSlider;
        public Toggle fullScreenToggle;

        private void Start() {
            // Cargar el volumen general guardado (por defecto a 1 si es la primera vez)
            if (masterSlider != null) {
                float savedMaster = PlayerPrefs.GetFloat("MasterVolume", 1f);
                masterSlider.value = savedMaster;
                ApplyMasterVolume(savedMaster);
            }

            // Cargar volumen de música
            if (musicSlider != null) {
                float savedMusic = PlayerPrefs.GetFloat("MusicVolume", 1f);
                musicSlider.value = savedMusic;
                ApplyMusicVolume(savedMusic);
            }

            // Cargar volumen de efectos (SFX)
            if (sfxSlider != null) {
                float savedSfx = PlayerPrefs.GetFloat("SfxVolume", 1f);
                sfxSlider.value = savedSfx;
                ApplySfxVolume(savedSfx);
            }

            // Configurar el estado inicial y guardado del Toggle de pantalla completa
            if (fullScreenToggle != null) {
                bool isFullScreen = PlayerPrefs.GetInt("FullScreen", Screen.fullScreen ? 1 : 0) == 1;
                fullScreenToggle.isOn = isFullScreen;
                Screen.fullScreen = isFullScreen;
            }
        }

        // --- MÉTODOS DE APLICACIÓN EN TIEMPO REAL (SIN GUARDAR EN DISCO TODAVÍA) ---

        public void SetMasterVolume(float volume) {
            ApplyMasterVolume(volume);
        }

        public void SetMusicVolume(float volume) {
            ApplyMusicVolume(volume);
        }

        public void SetSfxVolume(float volume) {
            ApplySfxVolume(volume);
        }

        public void SetFullScreen(bool isFullScreen) {
            Screen.fullScreen = isFullScreen;
        }

        // Métodos internos que aplican el audio de forma inmediata
        private void ApplyMasterVolume(float volume) {
            if (audioMixer != null) {
                audioMixer.SetFloat("Master", volume > 0 ? Mathf.Log10(volume) * 20 : -80f);
            } else {
                AudioListener.volume = volume;
            }
        }

        private void ApplyMusicVolume(float volume) {
            if (audioMixer != null) {
                audioMixer.SetFloat("Music", volume > 0 ? Mathf.Log10(volume) * 20 : -80f);
            }
        }

        private void ApplySfxVolume(float volume) {
            if (audioMixer != null) {
                audioMixer.SetFloat("SFX", volume > 0 ? Mathf.Log10(volume) * 20 : -80f);
            }
        }

        // --- BOTÓN DE GUARDAR CONFIGURACIÓN ---

        public void SaveConfiguration() {
            // Guardamos los valores actuales de los sliders y el toggle en PlayerPrefs
            if (masterSlider != null) PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
            if (musicSlider != null) PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
            if (sfxSlider != null) PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
            if (fullScreenToggle != null) PlayerPrefs.SetInt("FullScreen", fullScreenToggle.isOn ? 1 : 0);

            // Forzamos el guardado en disco
            PlayerPrefs.Save();

            Debug.Log("¡Configuración guardada correctamente!");

        }

        // Método para volver al menú principal
        public void ExitMenu() {
            SceneManager.LoadScene("UIStart");
        }
    }
}