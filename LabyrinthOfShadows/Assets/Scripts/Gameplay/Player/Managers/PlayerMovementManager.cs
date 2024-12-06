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

    private void FixedUpdate()
    {
        if (!_gameplayManager.IsPlaying()) return;

        var movementVector = _gameInputManager.GetMovementVectorNormalized();
        Move(movementVector);
    }

    private void Move(Vector2 movementVector)
    {
        var newPosition = _playerView.Rigidbody2D.position + movementVector * (Time.fixedDeltaTime * _playerSettings.MoveSpeed);
        _playerView.Rigidbody2D.MovePosition(newPosition);
    }

}