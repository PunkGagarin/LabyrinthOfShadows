using UI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OptionsDialog : BaseUIObject
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        private void Awake()
        {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
            musicSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
            soundSlider.onValueChanged.AddListener(OnSoundSliderValueChanged);
            Hide();
        }

        private void OnDestroy()
        {
            closeButton.onClick.RemoveListener(OnCloseButtonClicked);
            musicSlider.onValueChanged.RemoveListener(OnMusicSliderValueChanged);
            soundSlider.onValueChanged.RemoveListener(OnSoundSliderValueChanged);
        }

        private void OnCloseButtonClicked()
        {
            Hide();
        }

        private void OnMusicSliderValueChanged(float value)
        {
            // todo
        }

        private void OnSoundSliderValueChanged(float value)
        {
            // todo
        }
    }
}