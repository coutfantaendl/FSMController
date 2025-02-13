namespace FSM.Abstractions
{
    public interface IStateSwitcher
    {
        void SwitchState<TState>() where TState : IState;
    }
}