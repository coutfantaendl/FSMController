using UnityEngine;

namespace FSM.Abstractions
{
    public abstract class State : IState
    {
        protected readonly CharacterController Character;
        protected readonly PlayerStateMachine StateMachine;
        protected readonly Animator Animator;

        protected State(CharacterController character, PlayerStateMachine stateMachine, Animator animator)
        {
            this.Character = character;
            this.StateMachine = stateMachine;
            this.Animator = animator;
        }

        public abstract void Enter();
        public abstract void Exit();
        public abstract void Update();
    }
}