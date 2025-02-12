﻿using Core;
using Input;
using UnityEngine;

namespace Units.Player
{
    public class Player : UnitBase, ITakeDamage
    {
        private InputController inputController;
        public PlayerMovement playerMovement;
        public CameraMovement cameraMovement;

        [HideInInspector] public Health health;

        private void Awake()
        {
            inputController = GetComponent<InputController>();
            inputController.InitializeController(this);
            health = new Health(GameManager.Instance.playerData.maxHealth);
        }

        private void Start()
        {
            playerMovement.Init(inputController, cameraMovement);
            cameraMovement.Init(this, inputController, playerMovement);
            
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
