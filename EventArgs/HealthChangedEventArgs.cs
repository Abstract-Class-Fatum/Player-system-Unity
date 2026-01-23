using System;

public class HealthChangedEventArgs : EventArgs
{
    public int CurrentHealth { get; }
    public int MaxHealth { get; }
    public int AmountChanged { get; }

    public HealthChangedEventArgs(int currentHealth, int maxHealth, int amountChanged)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        AmountChanged = amountChanged
    }
}