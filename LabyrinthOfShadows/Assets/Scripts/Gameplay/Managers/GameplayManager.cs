using UnityEngine;

namespace Gameplay.Managers
{
    public class GameplayManager : MonoBehaviour
    {
        private bool _isPlaying = true;

        public bool IsPlaying()
        {
            return _isPlaying;
        }
    }
}