using Gameplay.Managers;
using Gameplay.Player.Settgins;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Managers
{
    public class PlayerLightManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerView playerView;

        [Inject] private PlayerSettings playerSettings;
        [Inject] private GameplayManager gameplayManager;

        private float timer = 0f;

        private void Update()
        {
            if (!gameplayManager.IsGamePlaying()) return;

            timer += Time.deltaTime;
            if (timer >= playerSettings.LightRadiusDecreasingInterval)
            {
                LowerLightLevel();
                timer = 0f;
            }
        }

        public void ResetLightLevel()
        {
            playerView.ConusLight.pointLightOuterRadius = playerSettings.MaxLightRadius;
        }

        private void LowerLightLevel()
        {
            if (playerView.ConusLight.pointLightOuterRadius == playerSettings.MinLightRadius) return;
            float nextValue = playerView.ConusLight.pointLightOuterRadius - playerSettings.LightRadiusDecreasePerSecond;
            if (nextValue <= playerSettings.MinLightRadius)
                nextValue = playerSettings.MinLightRadius;

            playerView.ConusLight.pointLightOuterRadius = nextValue;
        }
    }
}