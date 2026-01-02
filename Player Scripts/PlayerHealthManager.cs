using System;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    // References
    public PlayerController Control { get; private set; }

    // Lets PlayerController.cs initialize this component
    public void Initialize(PlayerController playerController)
    {
        Control = playerController;
    }

    // Health Stats
    public int currentHealth;
    private int maxHealth;
    private int minHealth; // 0 by default

    public void Awake()
    {
        maxHealth = currentHealth;
    }

    // Health events
    public event Action<int> OnHeal;
    public event Action<int> OnDamage;
    public event Action<int> OnDeath;

    public void HandleHeal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);

        OnHeal?.Invoke(amount);
    }

    public void HandleDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, minHealth, maxHealth);

        OnDamage?.Invoke(amount);

        if (currentHealth <= minHealth)
        {
            OnDeath?.Invoke();
        }
    }

}