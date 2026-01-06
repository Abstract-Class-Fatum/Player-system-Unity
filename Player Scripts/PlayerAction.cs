using System;
using UnityEngine;

public class PlayerAction : IPlayerComponent
{
    // Action Variables
    public int jumpPower;
    public float jumpCutoff;

    // Action properties
    public bool CanDash { get; private set; }

    // References
    private PlayerController Control { get; private set; }

    public void Initialize(PlayerController playerController)
    {
        Control = playerController;

        // Initialize others
        InitializeProperties();
    }

    private void InitializeProperties()
    {
        CanDash = false;
    }

    public void PlayerJump()
    {
        if (Control.IsJumping && Control.IsGrounded)
        {
            Control.Rb.linearVelocity = new Vector2(Control.Rb.linearVelocity.x, jumpPower);
        }
        else if (!Control.IsJumping && Control.Rb.linearVelocity.y >= jumpPower * jumpCutoff)
        {
            Control.Rb.linearVelocity = new Vector2(Control.Rb.linearVelocity.x, jumpPower * jumpCutoff);
        }
    }

    public IEnumerator DashCoroutine()
    {
        CanDash = false;
        ActionMachine.currentActionState = ActionMachine.ActionStates.Dash;
        
        yield new return WaitInSeconds(dashDuration);

    }

    
}