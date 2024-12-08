using Gameplay.Managers;
using UnityEngine;
using Zenject;

namespace Gameplay.Player.Managers
{
    public class PlayerTransformRotationFollower: MonoBehaviour
    {

        [Inject] private GameInputManager _inputManager;


        private void FixedUpdate()
        {
            Vector2 moveDirection = GetMoveDirection();

            if (moveDirection != Vector2.zero)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }

        private Vector2 GetMoveDirection()
        {
            return _inputManager.GetMovementVectorNormalized();
        }
    }
}