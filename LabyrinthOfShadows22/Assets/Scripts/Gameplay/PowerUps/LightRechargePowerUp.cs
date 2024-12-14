using Audio;
using Gameplay.Player.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.PowerUps
{
    public class LightRechargePowerUp : BasePowerUpView
    {
        [Inject] private PlayerLightManager playerLightManager;

        protected override void OnPickUp()
        {
            playerLightManager.ResetLightLevel();
            soundManager.PlayOneShotByType(GameAudioType.PowerUpPickedUp, 0);
        }
    }
}
