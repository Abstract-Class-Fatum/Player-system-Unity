public class RunState : IMoveState
{
    public void Enter(PlayerController playerController) { }

    public void Update(PlayerController playerController)
    {
        if (playerController.MoveInput.x == 0)
            playerController.MoveMachine.ChangeState(playerController.MoveMachine.IdleMoveState);
    }

    public void FixedUpdate(PlayerController playerController)
    {
        playerController.Movement.HandleMovement();
    }

    public void Exit(PlayerController playerController) { }
}