using Gameplay.PowerUps;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PowerUpInstaller : MonoInstaller
    {
        [SerializeField] private PowerUpSettings powerUpSettings;

        public override void InstallBindings()
        {
            Container.Bind<PowerUpSettings>().FromInstance(powerUpSettings).AsSingle();
        }
    }
}