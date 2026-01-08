using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerComponent
{
    // References
    public PlayerController Control { get; private set; }
    public PlayerStats playerStats { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController, PlayerStats playerStats)
    {
        Control = playerController;
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    // Health variables
    private float _currentHealth;
    private float _maxHealth;

    public float Health
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }

    public float MaxHealth
    {
        get => _maxHealth;
        set
        {
            float _oldMax = _maxHealth;
            _maxHealth = Mathf.Max(1, value);
            Health += _maxHealth - _oldMax;
        }
    }

    // Dead
    private bool _isDead;

    // Events
    public event Action<float> OnHealed;
    public event Action<float> OnDamaged;

    public event Action<float> OnAddMaxHealth;
    public event Action<float> OnRemoveMaxHealth;

    public event Action<float, float> OnHealthChange;

    public event Action OnDeath;

    public void Heal(float amount)
    {
        if (_isDead) return;

        Health += amount;

        OnHealed?.Invoke(amount);
        OnHealthChanged?.Invoke(Health, _maxHealth);
    }

    public void TakeDamage(float amount)
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

    
}