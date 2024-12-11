using System;
using UnityEngine;
using Zenject;

namespace Gameplay.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        public event EventHandler OnGamePaused;
        public event EventHandler OnGameUnPaused;

        private bool _isPlaying = true;
        
        // [Inject] GameOverUI gameOverUI;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePauseGame();
            }
        }

        public bool IsPlaying()
        {
            return _isPlaying;
        }

        public void SetGameOver()
        {
            _isPlaying = false;
            // gameOverUI.TurnOnGameOver();
        }

        public void TogglePauseGame()
        {
            if (_isPlaying)
            {
                Time.timeScale = 0f;
                OnGamePaused?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Time.timeScale = 1f;
                OnGameUnPaused?.Invoke(this, EventArgs.Empty);
            }
            _isPlaying = !_isPlaying;
        }

        public void SetLevelWon()
        {
            _isPlaying = false;
            //levelWonUi.
        }
    }
}