using UnityEngine;

namespace PlayerSettings
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int IsRunning = Animator.StringToHash("Run");
        private static readonly int IsJumping = Animator.StringToHash("Jump");
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void PlayIdle()
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetBool(IsJumping, false);
        }

        public void PlayRun()
        {
            _animator.SetBool(IsRunning, true);
            _animator.SetBool(IsJumping, false);
        }

        public void PlayJump()
        {
            _animator.SetBool(IsJumping, true);
        }
    }
}