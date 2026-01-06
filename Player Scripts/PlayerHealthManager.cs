using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerComponent
{
    // References
    public PlayerController Control { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
    }
}