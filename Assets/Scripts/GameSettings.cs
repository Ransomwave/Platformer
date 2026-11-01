using UnityEngine;
using UnityEngine.Audio;

namespace deltaformer {
    public static class GameSettings {
        private const string MasterVolumeKey = "MasterVolume";
        private const string MusicVolumeKey = "MusicVolume";
        private const string SfxVolumeKey = "SfxVolume";
        private const string FullScreenKey = "FullScreen";

        public static float MasterVolume {
            get => PlayerPrefs.GetFloat(MasterVolumeKey, 1f);
            set => PlayerPrefs.SetFloat(MasterVolumeKey, value);
        }

        public static float MusicVolume {
            get => PlayerPrefs.GetFloat(MusicVolumeKey, 1f);
            set => PlayerPrefs.SetFloat(MusicVolumeKey, value);
        }

        public static float SfxVolume {
            get => PlayerPrefs.GetFloat(SfxVolumeKey, 1f);
            set => PlayerPrefs.SetFloat(SfxVolumeKey, value);
        }

        public static bool FullScreen {
            get => PlayerPrefs.GetInt(FullScreenKey, Screen.fullScreen ? 1 : 0) == 1;
            set => PlayerPrefs.SetInt(FullScreenKey, value ? 1 : 0);
        }

        public static void Apply(AudioMixer mixer) {
            mixer.SetFloat("Master", ToDecibels(MasterVolume));
            mixer.SetFloat("Music", ToDecibels(MusicVolume));
            mixer.SetFloat("SFX", ToDecibels(SfxVolume));
            Screen.fullScreen = FullScreen;
        }

        public static void Save() {
            PlayerPrefs.Save();
        }

        private static float ToDecibels(float volume) {
            return volume > 0f ? Mathf.Log10(volume) * 20f : -80f;
        }
    }
}
