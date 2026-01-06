public interface IMoveState : IState
{
    void Update(PlayerController playerController);
    void FixedUpdate(PlayerController playerController);
}