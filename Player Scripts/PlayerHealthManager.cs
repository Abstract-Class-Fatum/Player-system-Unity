using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerComponent
{

    // Health variables
    private int _currentHealth;
    private int _minMaxHealth;
    private int _maxHealth;

    public int Health
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set
        {
            int _oldMax = _maxHealth;
            _maxHealth = Mathf.Max(_minMaxHealth, value);
            Health += _maxHealth - _oldMax;
        }
    }

    private bool _isDead;

    // Events
    public event Action<int> OnHealed;
    public event Action<int> OnDamaged;

    public event Action<int> OnAddMaxHealth;
    public event Action<int> OnRemoveMaxHealth;
    
    public event Action<int, int> OnHealthChange;
    public event Action OnDeath;

    public void Heal(int amount)
    {
        if (_isDead) return;

        Health += amount;

        OnHealed?.Invoke(amount);
        OnHealthChanged?.Invoke(Health, _maxHealth);
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