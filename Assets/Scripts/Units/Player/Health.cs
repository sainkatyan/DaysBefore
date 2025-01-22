using System;
using UnityEngine;

namespace Units.Player
{
    public class Health : MonoBehaviour
    {
        private float maxHealth;
        private float currentHealth;

        public event Action OnDeath; 
        public event Action<float> OnHealthChanged; 

        public Health(float maxHealth)
        {
            this.maxHealth = maxHealth;
            currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            OnHealthChanged?.Invoke(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                OnDeath?.Invoke();
            }
        }
    }
}
