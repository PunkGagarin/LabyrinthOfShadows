using UnityEngine;

namespace Gameplay.Managers
{
    public class GameInputManager : MonoBehaviour
    {
        private InputSystem_Actions _inputSystemActions;

        private void Start()
        {
            _inputSystemActions = new InputSystem_Actions();
            _inputSystemActions.Enable();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            var inputVector = _inputSystemActions.Player.Move.ReadValue<Vector2>();
            return inputVector.normalized;
            // return Vector2.zero;
        }

        // public Vector3 GetMousePosition()
        // {
        //     var mousePos = Mouse.current.position.ReadValue();
        //     return mousePos;
        // }

    }
}