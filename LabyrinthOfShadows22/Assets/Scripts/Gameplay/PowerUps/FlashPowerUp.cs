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

        private float flashDuration = 10f;
        private float flashIntensity = 3f; // todo ?
        
        private float timer = 0f;
        private bool isFlashing = false;

        private void Start()
        {
            light2D.intensity = 0f;
        }

        private void Update()
        {
            if (!gameplayManager.IsPlaying()) return;

            if (!isFlashing) return;

            timer += Time.deltaTime;
            if (timer >= flashDuration)
            {
                ToggleFlash();
                timer = 0f;
                gameObject.SetActive(false);
            }
        }

        protected override void OnPickUp()
        {
            if (isFlashing) return;
            ToggleFlash();
        }

        private void ToggleFlash()
        {
            isFlashing = !isFlashing;
            lightCollider.radius = light2D.pointLightOuterRadius; 
            lightCollider.gameObject.SetActive(true);
            light2D.intensity = light2D.intensity == 0f ? flashIntensity : 0f;
        }
    }
}