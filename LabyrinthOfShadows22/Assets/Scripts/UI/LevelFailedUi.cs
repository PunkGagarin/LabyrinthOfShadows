using SceneLoader;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LevelFailedUi : BaseUIObject
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button mainMenuButton;

        [Inject] private Loader loader;

        private void Awake()
        {
            restartButton.onClick.AddListener(OnRestartClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(OnRestartClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }

        private void OnRestartClicked()
        {
            // todo reopen current level
            loader.Load(Loader.Scene.GamePlayScene);
        }

        private void OnMainMenuButtonClicked()
        {
            loader.Load(Loader.Scene.MainMenuScene);
        }
    }
}