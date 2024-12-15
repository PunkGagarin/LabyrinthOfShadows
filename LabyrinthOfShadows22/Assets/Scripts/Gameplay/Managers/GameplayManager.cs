using Audio;
using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        [Inject] private PauseUi pauseUi;
        [Inject] private LevelFailedUi levelFailedUi;
        [Inject] private LevelCompletedUI levelCompletedUi;
        [Inject] private LevelViewProvider levelViewProvider;
        [Inject] private PlayStatManager _playStatManager;
        [Inject] private MusicManager _musicManager;
        [Inject] private SoundManager _soundManager;

        private bool _isPlaying = true;
        private bool _isPaused;

        private void Start()
        {
            levelViewProvider.PlayerWinViewProvider.OnPlayerWinZoneEnter += SetLevelWon;
            _musicManager.PlaySoundByType(GameAudioType.GameplayBgm, 0);
        }

        private void OnDestroy()
        {
            levelViewProvider.PlayerWinViewProvider.OnPlayerWinZoneEnter -= SetLevelWon;
        }

        private void Update()
        {
            if (_isPlaying && Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseGame();
            }
        }

        public bool IsGamePlaying()
        {
            return _isPlaying && !_isPaused;
        }

        public void TogglePauseGame()
        {
            Debug.Log("Trying to Toggle Pause");
            if (!_isPaused)
            {
                Time.timeScale = 0f;
                pauseUi.Show();
            }
            else
            {
                Time.timeScale = 1f;
                pauseUi.Hide();
            }
            _isPaused = !_isPaused;
        }

        public void SetLevelWon()
        {
            _soundManager.PlayOneShotByType(GameAudioType.LevelComplete, 0);
            _isPlaying = false;
            levelCompletedUi.Show();
            _playStatManager.UpdateLastCompletedLevel();
        }

        public void SetGameOver()
        {
            _soundManager.PlayOneShotByType(GameAudioType.LevelFailed, 0);
            _isPlaying = false;
            levelFailedUi.Show();
        }

        public void OnTutorialShowing()
        {
            _isPlaying = false;
        }

        public void OnTutorialShown()
        {
            _playStatManager.OnTutorialShown();
            _isPlaying = true;   
        }
    }

    public enum GameState
    {
        Playing,
        Paused,
        GameOver,
        Won
    }
}