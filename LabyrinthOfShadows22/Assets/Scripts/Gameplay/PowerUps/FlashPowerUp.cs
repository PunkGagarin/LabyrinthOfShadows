using Audio;
using Gameplay.Managers;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

namespace Gameplay.PowerUps
{
    public class FlashPowerUp : BasePowerUpView
    {
        [SerializeField] private Light2D light2D;
        [SerializeField] private CircleCollider2D lightCollider;

        [Inject] private GameplayManager gameplayManager;
        [Inject] private PowerUpSettings powerUpSettings;

        private float timer = 0f;
        private bool isFlashing = false;

        // private void Start()
        // {
        //     light2D.intensity = 0f;
        // }

        private void Update()
        {
            if (!gameplayManager.IsGamePlaying()) return;

            if (!isFlashing) return;

            timer += Time.deltaTime;
            if (timer >= powerUpSettings.FlashDuration)
            {
                ToggleFlash();
                timer = 0f;
                gameObject.SetActive(false);
            }
        }

        protected override void OnPickUp()
        {
            if (isFlashing) return;
            soundManager.PlayOneShotByType(GameAudioType.PowerUpPickedUp, 0);
            ToggleFlash();
        }

        private void ToggleFlash()
        {
            isFlashing = true;
            // var isFlashlightEnabled = light2D.intensity == 0f;
            if (isFlashing)
            {
                light2D.gameObject.SetActive(true);
                light2D.intensity = powerUpSettings.FlashIntensity;
                lightCollider.radius = light2D.pointLightOuterRadius;
                lightCollider.gameObject.SetActive(true);
            }
            else
            {
                // light2D.intensity = 0f;
                // lightCollider.radius = 0f;
                // lightCollider.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}