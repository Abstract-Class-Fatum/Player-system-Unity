public interface IStates
{
    void Enter(PlayerController control);
    void Update(PlayerController control);
    void FixedUpdate(PlayerController control);
    void Exit(PlayerController control);
}