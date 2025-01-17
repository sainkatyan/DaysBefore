using Assets.Scripts.Data;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Units.Player
{
    public class Player : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private PlayerData playerData;

        internal InputController inputController;
        public PlayerMovement playerMovement;
        public CameraMovement cameraMovement;

        private Health health;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
            inputController.InitializeController(this);

            playerMovement.Init(inputController, cameraMovement, playerData);
            cameraMovement.Init(inputController, playerMovement);
        }

        private void Start()
        {
            health = new Health(playerData.MaxHealth);
            Debug.Log($"Player set health : {playerData.MaxHealth}");
            SubscribeEvent();
        }

        private void SubscribeEvent()
        {
            health.OnHealthChanged += OnHealthChanged;
            health.OnDeath += Die;
        }

        public void TakeDamage(float damage)
        {
            health.TakeDamage(damage);
        }

        private void OnHealthChanged(float currentHealth)
        {
            Debug.Log($"Player health changed: {currentHealth}");
        }

        private void Die()
        {
            Debug.Log("Player has died.");
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            UnSubscribeEvents();
        }

        private void UnSubscribeEvents()
        {
            health.OnHealthChanged -= OnHealthChanged;
            health.OnDeath -= Die;
        }
    }
}
