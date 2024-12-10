using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SafeZoneInstaller : MonoInstaller
{

    [SerializeField]
    private SafeZoneManager _safeZoneManager;

    public override void InstallBindings()
    {
        Container.Bind<SafeZoneManager>().FromInstance(_safeZoneManager).AsSingle();
    }
}