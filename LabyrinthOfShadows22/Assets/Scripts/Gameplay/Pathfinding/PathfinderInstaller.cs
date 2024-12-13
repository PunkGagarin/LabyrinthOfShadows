using System.Collections;
using System.Collections.Generic;
using Gameplay.Pathfinding;
using UnityEngine;
using Zenject;

public class PathfinderInstaller : MonoInstaller
{

    [SerializeField]
    private GridManager _gridManager;
    //
    // [SerializeField]
    // private TilemapViewProvider _tilemapViewProvider;

    public override void InstallBindings()
    {
        Container.Bind<GridManager>().FromInstance(_gridManager).AsSingle();
        // Container.Bind<TilemapViewProvider>().FromInstance(_tilemapViewProvider).AsSingle();
        Container.Bind<Pathfinder>().AsSingle();
    }
}
