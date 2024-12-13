using SceneLoader;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuUi : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button selectLevelButton;
        [SerializeField] private OptionsDialog optionsDialog;
        [SerializeField] private SelectLevelUI selectLevelUI;

        [Inject] private Loader loader;

        private void Awake()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            optionsButton.onClick.AddListener(OnOptionsClicked);
            selectLevelButton.onClick.AddListener(OnSelectLevelClicked);
        }

        private void Start()
        {
            CheckSelectLevelButtonVisibility();
            SetStartGameButtonText();
        }

        private void SetStartGameButtonText()
        {
            var IsAtLeastOneLevelCompleted = false; // todo check settings
            startGameButton.GetComponentInChildren<TextMeshProUGUI>().text =
                IsAtLeastOneLevelCompleted ? "Continue Game" : "Start Game";
        }


        private void CheckSelectLevelButtonVisibility()
        {
            var allLevelsCompleted = true; // todo check settings
            selectLevelButton.gameObject.SetActive(allLevelsCompleted);
        }

        private void OnOptionsClicked()
        {
            optionsDialog.Show();
        }

        private void OnStartGameClicked()
        {
            loader.Load(Loader.Scene.GamePlayScene);
        }

        private void OnSelectLevelClicked()
        {
            selectLevelUI.Show();
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            optionsButton.onClick.RemoveListener(OnOptionsClicked);
            selectLevelButton.onClick.RemoveListener(OnSelectLevelClicked);
        }
    }
}