using Assets.Scripts.Core;
using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Units.Player
{
    public class Player : UnitBase, ITakeDamage
    {
        internal InputController inputController;
        public PlayerMovement playerMovement;
        public CameraMovement cameraMovement;

        private Health health;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
            inputController.InitializeController(this);
        }

        private void Start()
        {
            playerMovement.Init(inputController, cameraMovement);
            cameraMovement.Init(inputController, playerMovement);

            health = new Health(GameManager.Instance.playerData.MaxHealth);
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
