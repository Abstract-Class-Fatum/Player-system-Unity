public interface IStates
{
    void Enter(PlayerController player);
    void Update(PlayerController player);
    void FixedUpdate(PlayerController player);
    void Exit(PlayerController player);
}