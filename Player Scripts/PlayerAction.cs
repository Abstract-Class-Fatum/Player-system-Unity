using System;
using System.Collections;
using UnityEngine;

public class PlayerAction : IPlayerScript
{
    // Action Variables
    public int jumpPower;
    public float jumpCutoff;

    // Action properties
    public bool CanDash { get; private set; }

    // References
    public PlayerController Control { get; private set; }
    public PlayerStatsSO Stats { get; private set; }
    public void Initialize(PlayerController playerController, PlayerStatsSO playerStatsSO)
    {
        Control = playerController;
        Stats = playerStatsSO;

        // Initialize others
        InitializeProperties();
    }

    private void InitializeProperties()
    {
        CanDash = false;
    }

    public void PlayerJump()
    {
        if (Control.JumpPressed && Control.IsGrounded)
        {
            Control.Rb.linearVelocity = new Vector2(Control.Rb.linearVelocity.x, jumpPower);
        }
        else if (!Control.JumpPressed && Control.Rb.linearVelocity.y >= jumpPower * jumpCutoff)
        {
            Control.Rb.linearVelocity = new Vector2(Control.Rb.linearVelocity.x, jumpPower * jumpCutoff);
        }
    }

    public IEnumerator DashCoroutine()
    {
        return null;
    }   
}