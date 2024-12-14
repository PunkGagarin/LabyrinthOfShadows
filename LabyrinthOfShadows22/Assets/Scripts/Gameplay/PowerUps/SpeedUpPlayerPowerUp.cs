using Audio;
using Gameplay.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.PowerUps
{
    public class SpeedUpPlayerPowerUp : BasePowerUpView
    {
        [Inject] private GameplayManager gameplayManager;
        [Inject] private PlayerMovementManager playerMovementManager;
        [Inject] private PowerUpSettings powerUpSettings;

        private float timer = 0f;
        private bool isPickedUp = false;

        private void Update()
        {
            if (!gameplayManager.IsGamePlaying()) return;
            if (!isPickedUp) return;

            timer += Time.deltaTime;
            if (timer >= powerUpSettings.SpeedUpDuration)
            {
                playerMovementManager.ResetPlayerSpeed();
                timer = 0f;
                gameObject.SetActive(false);
            }
        }

        protected override void OnPickUp()
        {
            if (isPickedUp) return;
            soundManager.PlayOneShotByType(GameAudioType.PowerUpPickedUp, 0);
            playerMovementManager.IncreasePlayerSpeed(powerUpSettings.SpeedUpStrength);
            isPickedUp = true;
        }
    }
}