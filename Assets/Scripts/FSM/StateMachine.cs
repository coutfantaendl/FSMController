using System;
using System.Collections.Generic;
using System.Linq;
using FSM.Abstractions;
using FSM.States;
using PlayerSettings;
using PlayerSettings.PlayerConfigs;

namespace FSM
{
    public class StateMachine : IStateSwitcher
    {
        private readonly List<IState> _states;
        private IState _currentState;

        public StateMachine(PlayerConfig config, PlayerMovement movement, PlayerView view)
        {
            _states = new List<IState>
            {
                new IdlingState(movement, this, view),
                new RunningState(config.MovementSpeed, movement, this, view),
                new JumpingState(movement,this,view)
            };

            _currentState = _states[0];
            _currentState.Enter();
        }

        public void Update()
        {
            _currentState.Update();
        }

        public void SwitchState<TState>() where TState : IState
        {
            _currentState.Exit();
            _currentState = _states.FirstOrDefault(state => state is TState);

            if (_currentState is null)
                throw new ArgumentNullException($"State of type {typeof(TState).Name} not found");
            
            _currentState.Enter();
        }
    }
}