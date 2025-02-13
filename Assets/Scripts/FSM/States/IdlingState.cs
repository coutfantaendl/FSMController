using FSM.Abstractions;
using PlayerSettings;
using UnityEngine;

namespace FSM.States
{
    public class IdlingState : IState
    {
        private readonly PlayerMovement _movement;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly PlayerView _view;

        public IdlingState(PlayerMovement movement, IStateSwitcher stateSwitcher, PlayerView view)
        {
            _movement = movement;
            _stateSwitcher = stateSwitcher;
            _view = view;
        }
        
        public void Enter()
        {
            _view.PlayIdle();
        }

        public void Update()
        {
            if (_movement.HasMovementInput())
            {
                _stateSwitcher.SwitchState<RunningState>();
            }
            
            if (_movement.IsJumpPressed())
            {
                _stateSwitcher.SwitchState<JumpingState>();
            }
        }

        public void Exit() { }
        
    }
}