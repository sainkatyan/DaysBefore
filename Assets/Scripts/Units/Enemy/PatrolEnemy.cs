﻿using Units.Player;
using UnityEngine;

namespace Units.Enemy
{
    public class PatrolEnemy : Enemy
    {
        protected override void PerformAction()
        {
            EnemyMovementController.SetBehaviorPatrol();
        }

        private void OnCollisionEnter(Collision collision)
        {
            ITakeDamage damageable = collision.gameObject.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(DamageAmount);
            Debug.Log($"{DamageAmount} damage from enemy");

            Die();
        }
    }
}