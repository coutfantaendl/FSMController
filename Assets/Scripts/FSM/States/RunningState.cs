using FSM.Abstractions;
using PlayerSettings;

namespace FSM.States
{
    public class RunningState : IState
    {
        private readonly float _speed;
        private readonly PlayerMovement _movement;
        private readonly IStateSwitcher _stateSwitcher;
        private readonly PlayerView _view;

        public RunningState(float speed, PlayerMovement movement, IStateSwitcher stateSwitcher, PlayerView view)
        {
            _speed = speed;
            _movement = movement;
            _stateSwitcher = stateSwitcher;
            _view = view;
        }

        public void Enter()
        {
            _view.PlayRun();
        }

        public void Update()
        {
            if (!_movement.HasMovementInput())
            {
                _stateSwitcher.SwitchState<IdlingState>();
            }
            
            if (_movement.IsJumpPressed())
            {
                _stateSwitcher.SwitchState<JumpingState>();
            }
            _movement.Move(_speed);
        }

        public void Exit() { }
    }
}