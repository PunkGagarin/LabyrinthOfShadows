using Audio;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject
{

    public class SoundInstaller : MonoInstaller
    {

        [SerializeField] private SoundManager soundManager;
        [SerializeField] private MusicManager musicManager;

        public override void InstallBindings()
        {
            Container.Bind<SoundManager>().FromInstance(soundManager).AsSingle();
            Container.Bind<MusicManager>().FromInstance(musicManager).AsSingle();
        }
    }

}