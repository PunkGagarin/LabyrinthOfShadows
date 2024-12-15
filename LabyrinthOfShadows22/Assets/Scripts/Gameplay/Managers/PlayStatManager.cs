using System;
using Gameplay.Settings;
using UnityEngine;

namespace Gameplay.Managers
{
    class PlayStatManager : MonoBehaviour
    {
        [SerializeField] private LevelRepositorySO levelRepositorySo;

        private const int DEAFULT_LEVEL_INDEX = -1;
        private const String LAST_COMPLETED_LEVEL = "LastCompletedLevel";
        private const String TUTORIAL_SHOWN = "TutorialShown";

        public int CurrentLevelIndex { get; private set; }

        public bool IsGamePlayed() => PlayerPrefs.HasKey(LAST_COMPLETED_LEVEL);

        public bool IsAllLevelsCompleted() => GetLastCompletedLevel() == levelRepositorySo.LevelsCount;

        public void OnPlayStarting()
        {
            int currentLevel = GetLastCompletedLevel() + 1;
            int levelsCount = levelRepositorySo.LevelsCount;
            if (currentLevel >= levelsCount)
            {
                Debug.Log("All levels completed"); // todo
                return;
            }

            CurrentLevelIndex = currentLevel;
        }

        public void UpdateLastCompletedLevel()
        {
            SetLastCompletedLevel(CurrentLevelIndex);
        }

        public bool ShouldShowTutorial() => !PlayerPrefs.HasKey(TUTORIAL_SHOWN);

        public void OnTutorialShown() => PlayerPrefs.SetInt(TUTORIAL_SHOWN, 1);

        private int GetLastCompletedLevel()
        {
            return PlayerPrefs.GetInt(LAST_COMPLETED_LEVEL, DEAFULT_LEVEL_INDEX);
        }

        private void SetLastCompletedLevel(int levelIndex)
        {
            PlayerPrefs.SetInt(LAST_COMPLETED_LEVEL, levelIndex);
            PlayerPrefs.Save();
        }

        public void DowngradeLevel()
        {
            SetLastCompletedLevel(CurrentLevelIndex - 1);
        }
    }
}