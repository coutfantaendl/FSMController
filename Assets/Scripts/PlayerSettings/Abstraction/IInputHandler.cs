using UnityEngine;

namespace PlayerSettings.Abstraction
{
    public interface IInputHandler
    {
        public Vector3 GetMovementInput();
    }
}