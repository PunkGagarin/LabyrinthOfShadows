using Gameplay.Managers;
using SceneLoader;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LevelCompletedUI : BaseUIObject
    {
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button restartLevelButton;

        [Inject] private Loader loader;
        [Inject] private PlayStatManager playStatManager;

        private void Awake()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            restartLevelButton.onClick.AddListener(OnRestartLevelButtonClicked);
        }

        private void OnDestroy()
        {
            nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            restartLevelButton.onClick.RemoveListener(OnRestartLevelButtonClicked);
        }

        private void OnNextLevelClicked()
        {
            playStatManager.OnPlayStarting();
            loader.Load(Loader.Scene.GamePlayScene);
        }

        private void OnMainMenuButtonClicked()
        {
            loader.Load(Loader.Scene.MainMenuScene);
        }

        private void OnRestartLevelButtonClicked()
        {
            loader.Load(Loader.Scene.GamePlayScene);
        }
    }
}