using System;
using UnityEngine;

public class PlayerMovement : IPlayerComponent, IMoveable
{
    // References
    PlayerController Control { get; private set; }

    // Movement variables
    private float _baseMoveSpeed;
    private float _currentMoveSpeed;

    

    // Initialization
    public void Initialize(PlayerController playerController)
    {
        Control = playerController
    }

    public float MoveSpeed
    {
        get => _currentMoveSpeed
        set => _currentMoveSpeed => Mathf.max(0, value);
    }

    public void HandleMovement()
    {
        // Movement...sets the velocity of the Rigidbody to a vector that move towards the moveSpeed
        Control.Rb.linearVelocity = new Vector2(Mathf.MoveTowards(Control.Rb.linearVelocity.x, Control.MoveInput.x * MoveSpeed, acceleration * Time.fixedDeltaTime), Control.Rb.linearVelocity.y);
    }

    
}