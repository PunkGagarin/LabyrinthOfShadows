using UI;
using UnityEngine;
using Zenject;

namespace Gameplay.Installers
{
    public class GameUiInstaller : MonoInstaller
    {
        [SerializeField] private PauseUi pauseUI;
        [SerializeField] private LevelCompletedUI levelCompletedUI;
        [SerializeField] private LevelFailedUi levelFailedUi;

        public override void InstallBindings()
        {
            Container.Bind<PauseUi>().FromInstance(pauseUI).AsSingle();
            Container.Bind<LevelCompletedUI>().FromInstance(levelCompletedUI).AsSingle();
            Container.Bind<LevelFailedUi>().FromInstance(levelFailedUi).AsSingle();
        }
    }
}