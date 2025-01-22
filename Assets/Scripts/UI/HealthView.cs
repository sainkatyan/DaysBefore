using Core;
using Units.Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider = null;
        
        private Health health;
        private float maxHealth;
        private void Start()
        {
            health = GameManager.Instance.player.health;
            
            Subscribe();
            healthSlider.maxValue = GameManager.Instance.playerData.maxHealth;
            healthSlider.value = GameManager.Instance.playerData.maxHealth;
        }

        private void Subscribe()
        {
            health.OnHealthChanged += ChangeHealthView;
        }

        private void ChangeHealthView(float currentHealth)
        {
            healthSlider.value = currentHealth;
        }

        private void Unsubscribe()
        {
            health.OnHealthChanged -= ChangeHealthView;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
 