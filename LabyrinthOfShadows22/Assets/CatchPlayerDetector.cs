using Gameplay.Managers;
using UnityEngine;
using Zenject;

public class CatchPlayerDetector : MonoBehaviour
{
    [Inject] private GameplayManager _gameplayManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //EndGame
            Debug.Log("Game Over");
            _gameplayManager.SetGameOver();
        }
    }
}
