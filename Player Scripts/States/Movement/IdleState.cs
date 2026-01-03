public class IdleState : IState
{
    public void Enter(PlayerController player) { }

    public void Update(PlayerController player)
    {
        if (player.MoveInput.x != 0)
            player.MoveMachine.ChangeState(new RunState());
    }

    public void FixedUpdate(PlayerController player) { }

    public void Exit(PlayerController player) { }
}