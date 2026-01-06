using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerComponent
{

    // Health variables
    private int _currentHealth;
    private int _maxHealth;

    public int Health
    {
        get => _currentHealth;
        set => _currentHealth => Mathf.clamp(value, 0, _maxHealth);
    }

    // Events
    public event Action<int amount> OnHealthChange;
    public event Action OnDeath;

    public void HealHealth(int amount)
    {
        Health += amount;
        OnHealthChange?.Invoke(amount);
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        OnHealthChange?.Invoke(-amount);

        if (Health <= 0)
            HandleDeath();
    }

    public void HandleDeath()
    {
        OnDeath?.Invoke();
    }

    // References
    public PlayerController Control { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
    }
}