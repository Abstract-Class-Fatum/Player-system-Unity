public interface IState
{
    void Enter(PlayerController playerController);
    void Exit(PlayerController playerController);
}