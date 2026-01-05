using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, 
IPlayerComponent,
IMoveable
{
    // Movement variables
    public int moveSpeed;
    

    // References
    public PlayerController Control { get; private set; }
    
    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
    }

    private void Awake()
    {
        InitializeProperties();
    }

    private void InitializeProperties()
    {
        
    }

    public void HandleMovement()
    {
        // Movement...sets the velocity of the Rigidbody to a vector that move towards the moveSpeed
        Control.Rb.linearVelocity = new Vector2(Mathf.MoveTowards(Control.Rb.linearVelocity.x, Control.MoveInput.x * moveSpeed, acceleration * Time.fixedDeltaTime), Control.Rb.linearVelocity.y);
    }

    
}