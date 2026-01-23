using System;
using UnityEngine;

public class PlayerHealthManager : IPlayerScript
{

    // Health variables
    public bool isDead = false;

    private int _currentHealth;
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
            int oldMax = _maxHealth;
            _maxHealth = Mathf.Max(0, value);
            Health += (_maxHealth - oldMax);
        }
    }

    // Events
    public event Action<int> OnLoseMaxHealth;
    public event Action<int> OnGainMaxHealth;

    public event Action<HealthChange> OnHealthChanged;

    public event Action OnDeath;

    // Events
    public void Heal(int amount)
    {
        if (Health == MaxHealth) return;

        // Stores the old health
        int oldHealth = Health;

        Health += amount;

        // Records the change in health
        int healthChange = Health - oldHealth;

        OnHealthChanged?.Invoke(new HealthChanged(Health, MaxHealth, healthChange));
    }

    public void Damage(int amount)
    {
        if (isDead) return;

        int oldHealth = Health;

        Health -= amount;

        int healthChange = Health - oldHealth;

        OnHealthChanged?.Invoke(new HealthChanged(Health, MaxHealth, healthChange));

        if (Health <= 0)
            HandleDeath();
    }

    public void IncreaseMaxHealth(int amount)
    {
        MaxHealth += amount;

        OnGainMaxHealth?.Invoke(amount);
        OnHealthChanged?.Invoke(
            this,
            new HealthChangedEventArgs(Health, MaxHealth, healthChange)
        );
    }

    public void DecreaseMaxHealth(int amount)
    {
        MaxHealth -= amount;

        OnLoseMaxHealth?.Invoke(amount);
        OnHealthChanged?.Invoke(
            this,
            new HealthChangedEventArgs(Health, MaxHealth, healthChange)
        );
    }

    public void HandleDeath()
    {
        if (isDead) return;
        isDead = true;

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

        InitializeBaseHealth();
    }

    private void InitializeBaseHealth()
    {
        MaxHealth = Stats.baseHealth;
    }
}