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
        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }

    private bool _isDead;

    // Events
    public event Action<int> OnHealed;
    public event Action<int> OnDamaged;
    public event Action<int, int> OnHealthChange;
    public event Action OnDeath;

    public void Heal(int amount)
    {
        if (_isDead) return;

        Health += amount;

        OnHealed?.Invoke(amount);
        OnHealthChanged?.Invoke(Health, _maxHealth)
    }

    public void TakeDamage(int amount)
    {
        if (_isDead) return;

        Health -= amount;
        
        OnDamaged?.Invoke(amount);
        OnHealthChanged?.Invoke(Health, _maxHealth);

        if (Health <= 0)
            HandleDeath();
    }

    private void HandleDeath()
    {
        if (_isDead) return;

        _isDead = true;
        OnDeath?.Invoke();
    }

    // References
    public PlayerController Control { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }
}