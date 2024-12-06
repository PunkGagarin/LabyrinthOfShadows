using SceneLoader;
using UnityEngine;
using UnityEngine.UI;

namespace UI.LevelResult
{
    public class LevelCompletedUi : LevelResultUI
    {
        [SerializeField] private Button nextLevelButton;
   
        private void Awake()
        {
            base.Awake();
            nextLevelButton.onClick.AddListener(OnNextLevelClicked);
        }

        private void OnDestroy()
        {
            base.OnDestroy();
            nextLevelButton.onClick.RemoveListener(OnNextLevelClicked);
        }

        
        private void OnNextLevelClicked()
        {
            loader.Load(Loader.Scene.GamePlayScene);
            //todo
        }
    }
}