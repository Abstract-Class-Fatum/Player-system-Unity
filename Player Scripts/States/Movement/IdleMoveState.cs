public class IdleMoveState : IMoveState
{
    public void Enter(PlayerController playerController) { }

    public void Update(PlayerController playerController)
    {
        if (playerController.MoveInput.x != 0)
            playerController.MoveMachine.ChangeState(playerController.MoveMachine.RunState);
    }

    public void FixedUpdate(PlayerController playerController) { }

    public void Exit(PlayerController playerController) { }
}