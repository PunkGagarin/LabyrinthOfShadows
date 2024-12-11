using Gameplay.Enemies;
using UnityEngine;

public class DetectEnemyFlashlight : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        IStoppable enemy = other.GetComponent<IStoppable>();
        if (other.CompareTag("Enemy") && enemy != null)
        {
            enemy.IsFlashlighted = true;
            Debug.Log("Flashlighted");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        IStoppable enemy = other.GetComponent<IStoppable>();
        if (other.CompareTag("Enemy") && enemy != null)
        {
            enemy.IsFlashlighted = false;
            Debug.Log("un Flashlighted");
        }
    }
}