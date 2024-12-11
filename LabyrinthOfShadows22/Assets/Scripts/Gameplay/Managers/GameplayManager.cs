using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        private bool _isPlaying = true;

        [Inject] private PauseUi pauseUi;
        [Inject] private LevelFailedUi levelFailedUi;
        [Inject] private LevelCompletedUI levelCompletedUi;

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
            if (_isPlaying)
            {
                Time.timeScale = 0f;
                pauseUi.Show();
            }
            else
            {
                Time.timeScale = 1f;
                pauseUi.Hide();
            }

            _isPlaying = !_isPlaying;
        }

        public void SetLevelWon()
        {
            _isPlaying = false;
            levelCompletedUi.Show();
        }

        public void SetGameOver()
        {
            _isPlaying = false;
            levelFailedUi.Show();
        }
    }
}