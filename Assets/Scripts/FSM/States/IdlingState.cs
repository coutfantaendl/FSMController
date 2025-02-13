using FSM.Abstractions;
using UnityEngine;

namespace FSM.States
{
    public class IdlingState : IState
    {
        private readonly PlayerMovement _movement;
        private readonly IStateSwitcher _stateSwitcher;

        public IdlingState(PlayerMovement movement, IStateSwitcher stateSwitcher)
        {
            _movement = movement;
            _stateSwitcher = stateSwitcher;
        }
        
        public void Enter()
        {
           
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }
        
    }
}