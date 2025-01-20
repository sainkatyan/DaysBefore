﻿using Assets.Scripts.Units.Player;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Units.Enemy
{
    public class HunterEnemy : Enemy
    {
        [SerializeField] private EnemyHunterViewZone viewZone;
        public override void PerformAction()
        {
            enemyMovementController.SetBehaviorIdle();
            viewZone.Initialize(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            transform.LookAt(collision.transform.position);
            ITakeDamage damageable = collision.gameObject.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(DamageAmount);
            Debug.Log($"{DamageAmount} damage from enemy");

            TurnOnHuntingMode(false);

            Die();
        }

        public void TurnOnHuntingMode(bool isHuntingMode, GameObject huntTarget = null)
        {
            if (isHuntingMode)
            {
                enemyMovementController.SetBehaviorHunter(huntTarget);
            }
            else
            {
                enemyMovementController.SetBehaviorIdle();
    }
        }
    }
}