using Gameplay.Managers;
using SceneLoader;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI title;

        [Inject] private Loader loader;
        [Inject] private PlayStatManager playStatManager;

        private void Awake()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            restartLevelButton.onClick.AddListener(OnRestartLevelButtonClicked);
        }

        private void Start()
        {
            if (!playStatManager.IsThisLevelLast()) return;
            title.text = "Thanks for playing!";
            nextLevelButton.gameObject.SetActive(false);
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