using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerScript
{

    // Health variables
    private int _currentHealth;
    private readonly int _maxHealth;

    public int Health
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }

    // Events
    public event Action<int> OnHealthChange;
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
    public PlayerStatsSO Stats { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController, PlayerStatsSO playerStatsSO)
    {
        Control = playerController;
        Stats = playerStatsSO;
    }
}