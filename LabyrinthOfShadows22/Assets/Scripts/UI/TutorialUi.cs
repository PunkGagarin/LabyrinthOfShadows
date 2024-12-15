using Gameplay.Managers;
using UI.Core;
using UnityEngine;
using Zenject;

namespace UI
{
    public class TutorialUi : BaseUIObject
    {
        [Inject] private GameplayManager _gameplayManager;
        [Inject] private PlayStatManager _playStatManager;

        private void Start()
        {
            CheckVisibility();
        }

        private void Update()
        {
            if (Input.anyKeyDown)
            {
                _gameplayManager.OnTutorialShown();
                Hide();
            }
        }

        private void CheckVisibility()
        {
            if (_playStatManager.ShouldShowTutorial())
            {
                Show();
                _gameplayManager.OnTutorialShowing();
            }
            else
            {
                Hide();
            }
        }
    }
}