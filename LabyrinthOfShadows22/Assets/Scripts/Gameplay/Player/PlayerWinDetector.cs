using Gameplay.Managers;
using UnityEngine;
using Zenject;

public class PlayerWinDetector : MonoBehaviour
{
    [Inject] private GameplayManager _gameplayManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player won");
            _gameplayManager.SetLevelWon();
        }
    }
}