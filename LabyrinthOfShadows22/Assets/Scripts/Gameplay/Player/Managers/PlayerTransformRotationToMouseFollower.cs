using Gameplay.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Managers
{
    public class PlayerTransformRotationToMouseFollower : MonoBehaviour
    {
        [Inject] private PlayerView _playerView;
        [Inject] private GameplayManager _gameplayManager;
        [Inject] private GameInputManager _inputManager;
    
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void FixedUpdate()
        {
            if (!_gameplayManager.IsGamePlaying())
                return;
        
            Vector2 lookDirection = GetLookDirection();

            if (lookDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private Vector2 GetLookDirection()
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            // Vector3 mousePosition = _inputManager.GetMousePosition();
            mousePosition.z = 0f;
            Vector3 startPoint = _playerView.transform.position;
            Vector3 endPoint = mousePosition;
        
            Vector3 direction = (endPoint - startPoint).normalized;
        
            // Debug.Log($" Direction: {direction}");
            return direction;
        }
    }
}