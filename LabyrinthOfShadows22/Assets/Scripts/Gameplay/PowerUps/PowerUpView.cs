using Audio;
using UnityEngine;
using Zenject;

namespace Gameplay.PowerUps
{
    public abstract class BasePowerUpView : MonoBehaviour
    {
        [SerializeField] private GameObject spriteToHide;
        [Inject] protected SoundManager soundManager;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPickUp();
            spriteToHide.SetActive(false);
        }

        protected abstract void OnPickUp();
    }
}