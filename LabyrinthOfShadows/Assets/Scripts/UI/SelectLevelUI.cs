using SceneLoader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class SelectLevelUI : MonoBehaviour
    {
       [SerializeField] private Button backButton;
       [SerializeField] private Button levelOne;
       [SerializeField] private Button levelTwo;
       [SerializeField] private Button levelThree;

       [Inject] private Loader loader;
       
       private void Awake()
       {
           backButton.onClick.AddListener(OnBackButtonClicked);
           levelOne.onClick.AddListener(OnLevelOneClicked);
           levelTwo.onClick.AddListener(OnLevelTwoClicked);
           levelThree.onClick.AddListener(OnLevelThreeClicked);
       }

       private void OnDestroy()
       {
           backButton.onClick.RemoveListener(OnBackButtonClicked);
           levelOne.onClick.RemoveListener(OnLevelOneClicked);
           levelTwo.onClick.RemoveListener(OnLevelTwoClicked);
           levelThree.onClick.RemoveListener(OnLevelThreeClicked);
       }

       private void OnBackButtonClicked()
       {
           loader.Load(Loader.Scene.MainMenuScene);
       }

       private void OnLevelOneClicked()
       {
           //todo it correctly
           loader.Load(Loader.Scene.GamePlayScene);
       }

       private void OnLevelTwoClicked()
       {
           //todo it correctly
           loader.Load(Loader.Scene.MainMenuScene);
       }

       private void OnLevelThreeClicked()
       {
           //todo it correctly
           loader.Load(Loader.Scene.MainMenuScene);
       }
    }
}
