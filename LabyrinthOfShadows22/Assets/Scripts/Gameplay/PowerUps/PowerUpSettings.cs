using UnityEngine;

namespace Gameplay.PowerUps
{
    [CreateAssetMenu(fileName = "PowerUpSettingsSO", menuName = "Gameplay/Settings/PowerUpSettingsSo", order = 0)]
    public class PowerUpSettings : ScriptableObject
    {
        [field: SerializeField] public float SpeedUpDuration { get; private set; } = 3f;

        [field: SerializeField] public float SpeedUpStrength { get; private set; } = 3f;

        [field: SerializeField] public float FlashDuration { get; private set; } = 10f;

        [field: SerializeField] public float FlashIntensity { get; private set; } = 3f;
    }
}