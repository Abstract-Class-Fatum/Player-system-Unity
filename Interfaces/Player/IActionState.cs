public interface IActionState : IState
{
    void Update(PlayerController playerController);
    void FixedUpdate(PlayerController playerController);
}