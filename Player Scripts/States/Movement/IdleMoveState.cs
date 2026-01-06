public class IdleMoveState : IMoveState
{
    public void Enter(PlayerController control) { }

    public void Update(PlayerController control)
    {
        if (control.MoveInput.x != 0)
            control.MoveMachine.ChangeState(contol.MoveMachine.RunState);
    }

    public void FixedUpdate(PlayerController control) { }

    public void Exit(PlayerController control) { }
}