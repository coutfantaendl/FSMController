namespace FSM.Abstractions
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}