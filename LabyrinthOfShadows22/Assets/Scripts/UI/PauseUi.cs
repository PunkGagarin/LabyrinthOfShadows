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
        
        private void Awake()
        {
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            optionsButton.onClick.AddListener(OnOptionsButtonClicked);
            Hide();
        }

        private void OnDestroy()
        {
            resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            optionsButton.onClick.RemoveListener(OnOptionsButtonClicked);
        }

        private void OnOptionsButtonClicked()
        {
            optionsDialog.Show();
        }

        private void OnMainMenuButtonClicked()
        {
            Toggle();
            loader.Load(Loader.Scene.MainMenuScene);
        }

        private void OnResumeButtonClicked()
        {
            Toggle();
            Hide();
        }

        private void Toggle()
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;    
            }
            else
            {
                Time.timeScale = 0f;
            }
        }
        
        public void ShowPause()
        {
            Toggle();
            Show();
        }
    }
}