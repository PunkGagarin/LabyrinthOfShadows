using UI.Core;
using UnityEngine;

namespace Gameplay.PowerUps
{
    public abstract class BasePowerUpView : MonoBehaviour
    {
        
        [SerializeField] private GameObject spriteToHide;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            OnPickUp();
            spriteToHide.SetActive(false);
        }

        protected abstract void OnPickUp();
    }
}