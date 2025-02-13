using FSM.Abstractions;
using PlayerSettings;
using UnityEngine;

namespace FSM.States
{
    public class JumpingState : IState
    {
        private readonly PlayerMovement _movement;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly PlayerView _view;

        public JumpingState(PlayerMovement movement, IStateSwitcher stateSwitcher, PlayerView view)
        {
            _movement = movement;
            _stateSwitcher = stateSwitcher;
            _view = view;
        }

        public void Enter()
        {
            _view.PlayJump();
        }

        public void Update()
        {
            if (_movement.IsGrounded())
            {
                _movement.Jump();
                
                if (_movement.HasMovementInput())
                {
                    _stateSwitcher.SwitchState<RunningState>();
                }
                else
                {
                    _stateSwitcher.SwitchState<IdlingState>();
                }
            }
        }

        public void Exit() { }
    }
}