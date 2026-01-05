public interface IActionState : IState
{
    void Update(PlayerController control);
    void FixedUpdate(PlayerController control);
}