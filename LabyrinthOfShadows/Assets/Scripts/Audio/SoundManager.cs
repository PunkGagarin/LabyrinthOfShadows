using UnityEngine;
using UnityEngine.Serialization;

namespace Audio
{

    public class SoundManager : BaseAudioManager, ISoundManager
    {
        private const string PLAYER_PREFS_NAME = "SoundEffectVolume";
        private const float DEFAULT_VOLUME = 1f;

        [SerializeField] 
        private SoundsFactorySO soundsFactory;

        private void Awake()
        {
            SetPlayerPrefsName();
            Volume = PlayerPrefs.GetFloat(PLAYER_PREFS_NAME, DEFAULT_VOLUME);
        }

        private AudioClip GetRandomSoundByType(GameAudioType type)
        {
            return soundsFactory.GetRandomClipByType(type);
        }
        
        public void PlayRandomSoundByType(GameAudioType type, Transform transform, float volumeMultiplier)
        {
            var soundToPlay = GetRandomSoundByType(type);
            PlaySound(soundToPlay, transform.position, volumeMultiplier);
        }

        public void PlayRandomSoundByType(GameAudioType type, Transform transform)
        {
            var soundToPlay = GetRandomSoundByType(type);
            PlaySound(soundToPlay, transform.position);
        }

        public void PlayRandomSoundByType(GameAudioType type, Vector3 position)
        {
            var soundToPlay = GetRandomSoundByType(type);
            PlaySound(soundToPlay, position);
        }

        public void PlaySoundByType(GameAudioType type, int soundIndex, Vector3 position)
        {
            var soundToPlay = soundsFactory.GetClipByTypeAndIndex(type, soundIndex);
            PlaySound(soundToPlay, position);
        }

        private void PlaySound(AudioClip clip, Vector3 position, float volumeMultiplier = DEFAULT_VOLUME)
        {
            AudioSource.PlayClipAtPoint(clip, position, volumeMultiplier * Volume);
        }

        protected override void SetPlayerPrefsName()
        {
            playerPrefsName = PLAYER_PREFS_NAME;
        }
    }
}