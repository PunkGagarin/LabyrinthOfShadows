using SceneLoader;
using UnityEngine;
using Zenject;

public class LoaderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Loader>().AsSingle();
    }
}