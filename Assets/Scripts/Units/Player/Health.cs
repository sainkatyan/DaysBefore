using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float MaxHealth;
    private float CurrentHealth;

    public event Action OnDeath; 
    public event Action<float> OnHealthChanged; 

    public Health(float maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        OnHealthChanged?.Invoke(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDeath?.Invoke();
        }
    }
}
