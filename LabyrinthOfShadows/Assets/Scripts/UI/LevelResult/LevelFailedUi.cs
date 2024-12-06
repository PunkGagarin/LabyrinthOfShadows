using UnityEngine;
using UnityEngine.UI;

namespace UI.LevelResult
{
    public class LevelFailedUi : LevelResultUI
    {
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            base.Awake();
            restartButton.onClick.AddListener(OnRestartClicked);
        }

        private void OnDestroy()
        {
            base.OnDestroy();
            restartButton.onClick.RemoveListener(OnRestartClicked);
        }

        private void OnRestartClicked()
        {
            //todo
        }
    }
}