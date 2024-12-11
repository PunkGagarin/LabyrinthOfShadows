using UnityEngine;

namespace Gameplay.PowerUps
{
    public class SpeedUpPlayerPowerUp : BasePowerUpView
    {
        protected override void OnPickUp()
        {
            Debug.Log("SpeedUpPlayerPowerUp");
            //todo make player faster for two sec ?   
        }
    }
}