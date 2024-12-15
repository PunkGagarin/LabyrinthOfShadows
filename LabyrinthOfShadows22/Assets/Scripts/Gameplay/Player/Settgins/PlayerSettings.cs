using UnityEngine;

namespace Gameplay.Player.Settgins
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Gameplay/Settings/Player", order = 1)]
    public class PlayerSettings : ScriptableObject
    {

        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 5f;

        [field: SerializeField]
        public float LightRadiusDecreasePerSecond { get; private set; } = 0.11f;
        
        [field: SerializeField]
        public float LightRadiusIncreasePerSecond { get; private set; } = 0.5f;
        
        [field: SerializeField]
        public float LightRadiusDecreasingInterval { get; private set; } = 10f;
        
        [field: SerializeField]
        public float LightRadiusIncreasingInterval { get; private set; } = 1f;

        [field: SerializeField]
        public float MaxLightRadius { get; private set; } = 4f;
        
        [field: SerializeField]
        public float MinLightRadius { get; private set; } = 0f;
        
        [field: SerializeField]
        public float LightColliderScale { get; private set; } = 0.70f;
        
    }
}