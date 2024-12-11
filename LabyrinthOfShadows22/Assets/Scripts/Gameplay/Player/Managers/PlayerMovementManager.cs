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
    [Inject] private LevelBoundsView _levelBoundsView;


    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = _playerSettings.MoveSpeed;
    }

    private void FixedUpdate()
    {
        if (!_gameplayManager.IsPlaying()) return;

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
        return _levelBoundsView.LevelBounds.OverlapPoint(position);
    }

    private Vector2 ClampPositionToBounds(Vector2 position)
    {
        // Находим ближайшую точку на коллайдере к позиции
        var closestPoint = _levelBoundsView.LevelBounds.ClosestPoint(position);
        return closestPoint;
    }
}