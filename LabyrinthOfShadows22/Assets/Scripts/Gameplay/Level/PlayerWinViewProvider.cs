using System;
using Gameplay.Managers;
using UnityEngine;
using Zenject;

public class PlayerWinViewProvider : MonoBehaviour
{
    // [Inject] private GameplayManager _gameplayManager;

    public Action OnPlayerWinZoneEnter = delegate { };

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player won");
            OnPlayerWinZoneEnter.Invoke();
            // _gameplayManager.SetLevelWon();
        }
    }
}