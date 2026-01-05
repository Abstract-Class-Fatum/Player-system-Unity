public interface IState
{
    void Enter(PlayerController control);
    void Exit(PlayerController control);
}