using System;

public readonly struct HealthChanged
{
    public int CurrentHealth { get; }
    public int MaxHealth { get; }
    public int AmountChanged { get; }

    public HealthChanged(int currentHealth, int maxHealth, int amountChanged)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        AmountChanged = amountChanged;
    }
}