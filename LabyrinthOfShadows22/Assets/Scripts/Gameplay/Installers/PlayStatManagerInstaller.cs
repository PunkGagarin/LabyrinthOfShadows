using Gameplay.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class PlayStatManagerInstaller : MonoInstaller
    {
        [SerializeField] private PlayStatManager _playStatManager;

        public override void InstallBindings()
        {
            Container.Bind<PlayStatManager>().FromInstance(_playStatManager).AsSingle();
        }
    }
}