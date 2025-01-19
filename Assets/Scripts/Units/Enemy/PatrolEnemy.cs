using Assets.Scripts.Units.Player;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class PatrolEnemy : Enemy
    {
        public override void PerformAction()
        {
            enemyMovementController.SetBehaviorPatrol();
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