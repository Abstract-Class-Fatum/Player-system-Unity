using System;
using UnityEngine;

public class ActionStateMachine : IPlayerComponent
{
    // Stores current state
    private IActionState _currentActionState;

    // Cached states
    public IdleActionState IdleActionState { get; private set; }
    public DashState DashState { get; private set; }
    public JumpState JumpState { get; private set; }

    // References
    public PlayerController Control { get; private set; }

    // Initializes Player controller and sets state
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;

        NoActionState = new IdleActionState();
        DashState = new DashState();
        JumpState = new JumpState();
    }

    public void ChangeState(IActionState newState)
    {
        _currentActionState.Exit();
        _currentActionState = newState;
        _currentActionState.Enter();
    }

    public void Update()
    {
        _currentActionState.Update(Control);
    }

    public void FixedUpdate()
    {
        _currentActionState.FixedUpdate(Control);
    }
}