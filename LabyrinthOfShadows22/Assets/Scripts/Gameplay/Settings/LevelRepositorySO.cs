using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Settings
{
    
    [CreateAssetMenu( fileName = "LevelRepositorySO", menuName = "Gameplay/LevelRepositorySO")]
    public class LevelRepositorySO : ScriptableObject
    {

        [SerializeField]
        private List<CustomKeyValue<int, LevelViewProvider>> _levels;

        public LevelViewProvider GetLevelByIndex(int levelIndex)
        {
            return  _levels.FirstOrDefault(el => el.key == levelIndex)?.value;
        }
    }
}