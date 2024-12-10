using System;
using UnityEngine;

namespace Gameplay.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        public event EventHandler OnGamePaused;
        public event EventHandler OnGameUnPaused;

        private bool _isPlaying = true;

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

        public void TogglePauseGame()
        {
            _isPlaying = !_isPlaying;
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
        }
    }
}