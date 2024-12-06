using SceneLoader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.LevelResult
{
    public class LevelResultUI : MonoBehaviour
    {
        [SerializeField] protected Button mainMenuButton;
        [SerializeField] protected Button selectLevelButton;
        [Inject] protected Loader loader;
        
        protected void Awake()
        {
            mainMenuButton.onClick.AddListener(OnMainMenuClicked);
            selectLevelButton.onClick.AddListener(OnSelectLevelClicked);
        }

        protected void OnDestroy()
        {
            mainMenuButton.onClick.RemoveListener(OnMainMenuClicked);
            selectLevelButton.onClick.RemoveListener(OnSelectLevelClicked);
        }
        
        private void OnMainMenuClicked()
        {
            loader.Load(Loader.Scene.MainMenuScene);
        }

        private void OnSelectLevelClicked()
        {
            loader.Load(Loader.Scene.SelectLevelScene);
        }
    }
}