using System;
using UnityEngine;

public class PlayerMovement : IPlayerScript, IMoveable
{
    // Movement variables
    private float _baseMoveSpeed;
    private float _currentMoveSpeed;

    public float MoveSpeed
    {
        get => _currentMoveSpeed;
        set => _currentMoveSpeed = Mathf.Max(0, value);
    }

    private float _acceleration = 20f;

    // References
    public PlayerController Control { get; private set; }
    public PlayerStatsSO Stats { get; private set; }

    // Initialization
    public void Initialize(PlayerController playerController, PlayerStatsSO playerStatsSO)
    {
        Control = playerController;
        Stats = playerStatsSO;

        SetMovementStats();
    }

    private void SetMovementStats()
    {
        _baseMoveSpeed = Stats.baseMoveSpeed;
        _currentMoveSpeed = _baseMoveSpeed;
    }

    public void HandleMovement()
    {
        if (Control == null) return;

        // Movement...sets the velocity of the Rigidbody to a vector that move towards the moveSpeed
        Control.Rb.linearVelocity = new Vector2(Mathf.MoveTowards(Control.Rb.linearVelocity.x, Control.MoveInput.x * MoveSpeed, _acceleration * Time.fixedDeltaTime), Control.Rb.linearVelocity.y);
    }

    
}