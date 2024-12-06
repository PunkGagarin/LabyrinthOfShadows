using Gameplay.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class GameplayInstaller : MonoInstaller
    {

        [SerializeField]
        private GameInputManager _gameInputManager;

        [SerializeField]
        private GameplayManager _gameplayManager;

        public override void InstallBindings()
        {
            Container.Bind<GameInputManager>().FromInstance(_gameInputManager).AsSingle();
            Container.Bind<GameplayManager>().FromInstance(_gameplayManager).AsSingle();
        }
    }
}