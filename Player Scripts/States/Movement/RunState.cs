public class RunState : IState
{
    public void Enter(PlayerController player) { }

    public void Update(PlayerController player)
    {
        if (player.MoveInput.x == 0)
            player.MoveMachine.ChangeState(new IdleState());
    }

    public void FixedUpdate(PlayerController player)
    {
        player.Movement.HandleMovement();
    }

    public void Exit(PlayerController player) { }
}