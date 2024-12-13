using Gameplay.Settings;
using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField]
    private LevelRepositorySO _levelRepository;

    [SerializeField]
    private Transform _levelHolder;

    public override void InstallBindings()
    {
        Container.Bind<LevelViewProvider>().FromMethod(InstantiateLevel).AsSingle().NonLazy();
    }

    private LevelViewProvider InstantiateLevel()
    {
        int levelIndex = GetLastPlayerLevel();
        var levelViewProvider = _levelRepository.GetLevelByIndex(levelIndex);
        LevelViewProvider level = Instantiate(levelViewProvider, _levelHolder);
        return level;
    }

    private int GetLastPlayerLevel()
    {
        var level = PlayerPrefs.GetInt("PlayerLevel", 0);
        return level;
    }
}
