using Gameplay.Enemies;
using UnityEngine;

namespace Gameplay.Player
{
    public class DetectEnemyFlashlight : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            IStoppable enemy = other.GetComponent<IStoppable>();
            if (other.CompareTag("Enemy") && enemy != null)
            {
                enemy.IsFlashlighted = true;
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            IStoppable enemy = other.GetComponent<IStoppable>();
            if (other.CompareTag("Enemy") && enemy != null)
            {
                enemy.IsFlashlighted = false;
            }
        }
    }
}