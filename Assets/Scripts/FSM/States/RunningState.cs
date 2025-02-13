using FSM.Abstractions;
using UnityEngine;

namespace FSM.States
{
    public class RunningState : IState
    {
        private readonly float _speed;
        private readonly PlayerMovement _movement;
        private readonly IStateSwitcher _stateSwitcher;

        public RunningState(float speed, PlayerMovement movement, IStateSwitcher stateSwitcher)
        {
            _speed = speed;
            _movement = movement;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            
        }

        public void Update()
        {
            _movement.Move(_speed);
        }

        public void Exit()
        {
            
        }
    }
}