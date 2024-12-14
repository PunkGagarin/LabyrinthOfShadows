using Gameplay.Managers;
using Gameplay.Settings;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private int _defaultLevelIndex = 0;
    [SerializeField] private LevelRepositorySO _levelRepository;
    [SerializeField] private Transform _levelHolder;
    [SerializeField] private bool isDebug = false;

    [Inject] private PlayStatManager _playStatManager;

    public override void InstallBindings()
    {
        // Container.Bind<LevelViewProvider>().FromMethod(InstantiateLevel).AsSingle().NonLazy();

        int levelIndex = isDebug ? _defaultLevelIndex : GetLevelToLoad();
        var levelViewProvider = _levelRepository.GetLevelByIndex(levelIndex);

        Container.Bind<LevelViewProvider>()
            .FromComponentInNewPrefab(levelViewProvider)
            .WithGameObjectName("Level" + levelIndex)
            .UnderTransform(_levelHolder)
            // .OnInstantiated(SetSettings)
            .AsSingle();
    }

    private LevelViewProvider InstantiateLevel()
    {
        int levelIndex = GetLevelToLoad();
        var levelViewProvider = _levelRepository.GetLevelByIndex(levelIndex);
        LevelViewProvider level = Instantiate(levelViewProvider, _levelHolder);
        // Container.Resolve(level);
        
        return level;
    }

    private int GetLevelToLoad()
    {
        return _playStatManager.CurrentLevelIndex;
    }
}