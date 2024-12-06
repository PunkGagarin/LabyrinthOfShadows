using UnityEngine;

namespace Gameplay.Player.Settgins
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Gameplay/Settings/Player", order = 1)]
    public class PlayerSettings : ScriptableObject
    {

        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 5f;

        [field: SerializeField]
        public float LightRadiusDecreasePerSecond { get; private set; } = 0.05f;

        [field: SerializeField]
        public float MaxLightRadius { get; private set; } = 20f;
    }
}