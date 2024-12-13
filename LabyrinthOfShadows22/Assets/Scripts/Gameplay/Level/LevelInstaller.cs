using Gameplay.Settings;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField]
    private int _defaultLevelIndex = 0;
    
    [SerializeField]
    private LevelRepositorySO _levelRepository;

    [SerializeField]
    private Transform _levelHolder;

    public override void InstallBindings()
    {
        // Container.Bind<LevelViewProvider>().FromMethod(InstantiateLevel).AsSingle().NonLazy();
        
        int levelIndex = GetLastPlayerLevel();
        var levelViewProvider = _levelRepository.GetLevelByIndex(levelIndex);
        
        Container.Bind<LevelViewProvider>()
            .FromComponentInNewPrefab(levelViewProvider)
            .WithGameObjectName("Level")
            .UnderTransform(_levelHolder)
            // .OnInstantiated(SetSettings)
            .AsSingle();
    }

    private LevelViewProvider InstantiateLevel()
    {
        int levelIndex = GetLastPlayerLevel();
        var levelViewProvider = _levelRepository.GetLevelByIndex(levelIndex);
        LevelViewProvider level = Instantiate(levelViewProvider, _levelHolder);
        // Container.Resolve(level);

        


        return level;
    }

    private int GetLastPlayerLevel()
    {
        var level = PlayerPrefs.GetInt("PlayerLevel", _defaultLevelIndex);
        return level;
    }
}