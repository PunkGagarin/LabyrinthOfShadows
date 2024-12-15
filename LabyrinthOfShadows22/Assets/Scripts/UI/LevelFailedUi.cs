using Gameplay.Managers;
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
        [Inject] private PlayStatManager playStatManager;

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
            loader.Load(Loader.Scene.GamePlayScene);
        }

        private void OnMainMenuButtonClicked()
        {
            playStatManager.DowngradeLevel();
            loader.Load(Loader.Scene.MainMenuScene);
        }
    }
}