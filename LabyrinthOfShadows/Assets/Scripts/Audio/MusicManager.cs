using UnityEngine;

namespace Audio
{
    public class MusicManager : BaseAudioManager
    {

        private const string PLAYER_PREFS_NAME = "MusicVolume";
        private const float DEFAULT_VOLUME = .3f;

        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            SetPlayerPrefsName();
        
            Volume = PlayerPrefs.GetFloat(PLAYER_PREFS_NAME, DEFAULT_VOLUME);
            audioSource.volume = Volume;
        }


        public override void ChangeVolume()
        {
            base.ChangeVolume();
            audioSource.volume = Volume;
        }

        public override void ChangeVolume(float _volume)
        {
            Volume = _volume;
            ChangeVolume();
        }

        protected override void SetPlayerPrefsName()
        {
            playerPrefsName = PLAYER_PREFS_NAME;
        }
    
    }
}