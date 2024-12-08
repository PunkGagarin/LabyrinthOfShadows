using UnityEngine;

namespace Zenject
{
    public class GameStateInstaller : MonoInstaller
    {
        [SerializeField] private GameStateManager gameStateManager;

        public override void InstallBindings()
        {
            Container.Bind<GameStateManager>().FromInstance(gameStateManager).AsSingle();
        }
    }
}