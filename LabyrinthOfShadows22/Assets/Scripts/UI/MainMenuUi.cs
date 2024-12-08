using SceneLoader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MainMenuUi : MonoBehaviour
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private OptionsDialog optionsDialog;

        private Loader loader;

        [Inject]
        public void Init(Loader loader)
        {
            this.loader = loader;
        }

        private void Awake()
        {
            startGameButton.onClick.AddListener(OnStartGameClicked);
            optionsButton.onClick.AddListener(OnOptionsClicked);
        }

        private void OnDestroy()
        {
            startGameButton.onClick.RemoveListener(OnStartGameClicked);
            optionsButton.onClick.RemoveListener(OnOptionsClicked);
        }

        private void OnOptionsClicked()
        {
            optionsDialog.Show();
        }

        private void OnStartGameClicked()
        {
            loader.Load(Loader.Scene.GamePlayScene);
        }
    }
}