using UnityEngine;
using UnityEngine.UI;

namespace UI.LevelResult
{
    public class LevelFailedUi : LevelResultUI
    {
        [SerializeField] private Button restartButton;

        private new void Awake()
        {
            base.Awake();
            restartButton.onClick.AddListener(OnRestartClicked);
        }

        private new void OnDestroy()
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