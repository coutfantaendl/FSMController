using System;
using PlayerSettings.Abstraction;
using UnityEngine;
using UnityEngine.InputSystem;

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
            throw new NotImplementedException();
        }
    }
}