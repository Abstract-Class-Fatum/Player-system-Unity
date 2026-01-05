public interface IMoveState : IState
{
    void Update(PlayerController control);
    void FixedUpdate(PlayerController control);
}