using Gameplay.Managers;
using Gameplay.Player.Settgins;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Managers
{
    public class PlayerLightManager : MonoBehaviour
    {
        [SerializeField] private PlayerView playerView;

        [Inject] private PlayerSettings playerSettings;
        [Inject] private GameplayManager gameplayManager;

        private float decreaseTimer = 0f;
        private float increaseTimer = 0f;
        private bool isPlayerInSafeZone = false;

        private void Awake()
        {
            playerView.ConusLight.pointLightInnerRadius = playerSettings.MinLightRadius;
            ResetLightLevel();
        }

        private void Update()
        {
            if (!gameplayManager.IsGamePlaying()) return;

            decreaseTimer += Time.deltaTime;
            increaseTimer += Time.deltaTime;

            if (isPlayerInSafeZone)
            {
                TryIncrease();
            }
            else
            {
                TryDecrease();
            }
        }

        private void TryIncrease()
        {
            if (increaseTimer >= playerSettings.LightRadiusIncreasingInterval)
            {
                IncreaseLightLevel();
                increaseTimer = 0f;
            }
        }

        private void TryDecrease()
        {
            if (decreaseTimer >= playerSettings.LightRadiusDecreasingInterval)
            {
                DecreaseLightLevel();
                decreaseTimer = 0f;
            }
        }

        public void ResetLightLevel()
        {
            playerView.ConusLight.pointLightOuterRadius = playerSettings.MaxLightRadius;
            UpdateCollider(playerSettings.MaxLightRadius);
        }

        private void DecreaseLightLevel()
        {
            if (playerView.ConusLight.pointLightOuterRadius == playerSettings.MinLightRadius) return;

            float nextValue = playerView.ConusLight.pointLightOuterRadius - playerSettings.LightRadiusDecreasePerSecond;
            if (nextValue <= playerSettings.MinLightRadius)
                nextValue = playerSettings.MinLightRadius;

            playerView.ConusLight.pointLightOuterRadius = nextValue;
            UpdateCollider(nextValue);
        }

        private void IncreaseLightLevel()
        {
            if (playerView.ConusLight.pointLightOuterRadius == playerSettings.MaxLightRadius) return;

            float nextValue = playerView.ConusLight.pointLightOuterRadius + playerSettings.LightRadiusIncreasePerSecond;
            if (nextValue >= playerSettings.MaxLightRadius)
                nextValue = playerSettings.MaxLightRadius;

            playerView.ConusLight.pointLightOuterRadius = nextValue;
            UpdateCollider(nextValue);
        }

        private void UpdateCollider(float nextValue)
        {
            var value = nextValue * playerSettings.LightColliderScale;
            playerView.ConusLightCollider.transform.localScale = new Vector3(value, value / 2, 1f);
        }

        public void OnPlayerInSafeZone()
        {
            isPlayerInSafeZone = true;
        }

        public void OnPlayerOutOfSafeZone()
        {
            isPlayerInSafeZone = false;
        }
    }
}