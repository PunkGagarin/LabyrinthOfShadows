using System;
using Gameplay.Managers;
using Gameplay.Player.Settgins;
using UnityEngine;
using Zenject;

public class PlayerMovementManager : MonoBehaviour
{
    [Inject] private PlayerView _playerView;
    [Inject] private GameInputManager _gameInputManager;
    [Inject] private GameplayManager _gameplayManager;
    [Inject] private PlayerSettings _playerSettings;
    [Inject] private LevelViewProvider _levelViewProvider;

    private float moveSpeed;


    private void Start()
    {
        moveSpeed = _playerSettings.MoveSpeed;
        _playerView.transform.position = _levelViewProvider.PlayerSpawnPoint.position;
    }

    private void FixedUpdate()
    {
        if (!_gameplayManager.IsGamePlaying()) return;

        var movementVector = _gameInputManager.GetMovementVectorNormalized();
        Move(movementVector);
    }

    private void Move(Vector2 movementVector)
    {
        var newPosition = _playerView.Rigidbody2D.position +
                          movementVector * (Time.fixedDeltaTime * moveSpeed);

        if (IsPositionInsideBounds(newPosition))
            MoveTo(newPosition);
        else
        {
            var clampPosition = ClampPositionToBounds(newPosition);
            MoveTo(clampPosition);
        }
    }

    private void MoveTo(Vector2 newPosition)
    {
        _playerView.Rigidbody2D.MovePosition(newPosition);
    }

    private bool IsPositionInsideBounds(Vector2 position)
    {
        return _levelViewProvider.LevelBoundsView.LevelBounds.OverlapPoint(position);
    }

    private Vector2 ClampPositionToBounds(Vector2 position)
    {
        // Находим ближайшую точку на коллайдере к позиции
        var closestPoint = _levelViewProvider.LevelBoundsView.LevelBounds.ClosestPoint(position);
        return closestPoint;
    }

    public void IncreasePlayerSpeed(float value)
    {
        moveSpeed += value;
    }

    public void ResetPlayerSpeed()
    {
        moveSpeed = _playerSettings.MoveSpeed;
    }
}