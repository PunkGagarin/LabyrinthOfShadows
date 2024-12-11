using Gameplay.Player.Managers;
using Gameplay.Player.Settgins;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField]
    private PlayerView _playerView;

    [SerializeField]
    private PlayerMovementManager _playerMovementManager;

    [SerializeField]
    private PlayerSettings _playerSettings;

    [SerializeField]
    private PlayerLightManager _playerLightManager;

    public override void InstallBindings()
    {
        Container.Bind<PlayerView>().FromInstance(_playerView).AsSingle();
        Container.Bind<PlayerMovementManager>().FromInstance(_playerMovementManager).AsSingle();
        Container.Bind<PlayerSettings>().FromInstance(_playerSettings).AsSingle();
        Container.Bind<PlayerLightManager>().FromInstance(_playerLightManager).AsSingle();
    }
}