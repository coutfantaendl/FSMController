using FSM.Abstractions;
using UnityEngine;

namespace FSM.States
{
    public class RunningState : State
    {
        public RunningState(CharacterController character, PlayerStateMachine stateMachine, Animator animator) 
            : base(character, stateMachine, animator)
        {
        }

        public override void Enter()
        {
            throw new System.NotImplementedException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void Exit()
        {
            throw new System.NotImplementedException();
        }

        
    }
}