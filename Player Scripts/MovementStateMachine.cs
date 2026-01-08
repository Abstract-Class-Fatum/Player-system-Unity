using System;
using UnityEngine;

public class MovementStateMachine : IPlayerComponent
{
    // Stores current state
    private IMoveState _currentMoveState; 

    // Cached states
    public IdleMoveState IdleMoveState { get; private set; }
    public RunState RunState { get; private set; }

    // References
    public PlayerController Control { get; private set; }

    // Initializes the state machine and cached states along with setting it to idle
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;

        IdleState = new IdleMoveState();
        RunState  = new RunState();

        ChangeState(IdleState);
    }

    // Name says it all
    public void ChangeState(IMoveState newState)
    {
        // If the state is already the new state then it 
        if (newState == null)
            throw new Exception();

        if (newState == _currentMoveState) return;

        _currentMoveState?.Exit(Control);
        _currentMoveState = newState;
        _currentMoveState.Enter(Control);
    }

    // Updates state logic via Update()
    public void Update()
    {
        if (_currentMoveState == null || Control == null) return;

        _currentMoveState.Update(Control);
    }

    // Updates state logic via FixedUpdate();
    public void FixedUpdate()
    {
        if (_currentMoveState == null || Control == null) return;

        _currentMoveState.FixedUpdate(Control);
    }
}