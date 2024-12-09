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
        [SerializeField] private Button selectLevelButton;
        
        
        [Inject] private Loader loader;
        
        private void Awake()
        {
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
            selectLevelButton.onClick.AddListener(OnSelectLevelButtonClicked);
        }

        private void OnDestroy()
        {
            nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);
            mainMenuButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            selectLevelButton.onClick.RemoveListener(OnSelectLevelButtonClicked);
        }

        private void OnNextLevelClicked()
        {
            // todo open next level
            loader.Load(Loader.Scene.GamePlayScene);
        }

        private void OnMainMenuButtonClicked()
        {
            loader.Load(Loader.Scene.MainMenuScene);
        }

        private void OnSelectLevelButtonClicked()
        {
            loader.Load(Loader.Scene.GamePlayScene); //todo
        }
    }
}
