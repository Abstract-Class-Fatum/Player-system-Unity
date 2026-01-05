public class RunState : IMoveState
{
    public void Enter(PlayerController control) { }

    public void Update(PlayerController control)
    {
        if (control.MoveInput.x == 0)
            control.MoveMachine.ChangeState(player.MoveMachine.IdleState);
    }

    public void FixedUpdate(PlayerController control)
    {
        player.Movement.HandleMovement();
    }

    public void Exit(PlayerController control) { }
}