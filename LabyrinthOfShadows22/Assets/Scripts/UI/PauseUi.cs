using System;
using Gameplay.Managers;
using SceneLoader;
using UI.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class PauseUi : BaseUIObject
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button mainMenuButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private OptionsDialog optionsDialog;

        [Inject] private Loader loader;
        [Inject] private GameplayManager gameplayManager;

        private void Awake()
        {
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            optionsButton.onClick.AddListener(OnOptionsButtonClicked);
            gameplayManager.OnGamePaused += OnGamePaused;
            gameplayManager.OnGameUnPaused += OnGameUnPaused;
            Hide();
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            optionsButton.onClick.RemoveListener(OnOptionsButtonClicked);
            gameplayManager.OnGamePaused -= OnGamePaused;
            gameplayManager.OnGameUnPaused -= OnGameUnPaused;
        }

        private void OnOptionsButtonClicked()
        {
            optionsDialog.Show();
        }

        private void OnMainMenuButtonClicked()
        {
            gameplayManager.TogglePauseGame();
            loader.Load(Loader.Scene.MainMenuScene);
        }

        private void OnResumeButtonClicked()
        {
            gameplayManager.TogglePauseGame();
        }

        private void OnGameUnPaused(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnGamePaused(object sender, EventArgs e)
        {
            Show();
        }
    }
}