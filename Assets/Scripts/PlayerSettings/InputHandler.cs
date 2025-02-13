using PlayerSettings.Abstraction;
using UnityEngine;

namespace PlayerSettings
{
    public class InputHandler : MonoBehaviour, IInputHandler
    {
        private InputSystem_Actions _inputSystemActions;
        private void Awake()
        {
            _inputSystemActions = new InputSystem_Actions();
            _inputSystemActions.Enable();
        }

        private void OnEnable()
        {
            _inputSystemActions?.Enable();
        }

        private void OnDisable()
        {
            _inputSystemActions?.Disable();
        }

        public Vector3 GetMovementInput()
        {
            var input = _inputSystemActions.Player.Move.ReadValue<Vector2>();
            return new Vector3(input.x, 0, input.y);
        }
        
        public bool IsJumpPressed()
        {
            return _inputSystemActions.Player.Jump.WasPressedThisFrame();
        }
    }
}