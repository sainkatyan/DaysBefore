using Core;
using Units.Player;
using UnityEngine;

namespace Units.Enemy
{
    public class HunterEnemy : Enemy
    {
        private Transform target;
        private float chaseRange;
        private bool isHunting = false;

        protected override void PerformAction()
        {
            EnemyMovementController.SetBehaviorIdle();
            target = GameManager.Instance.player.transform;
            chaseRange = GameManager.Instance.enemyData.hunterEnemy.chaseRange;
        }
        
        public void FixedUpdate()
        {
            if (IsTargetInSight(target, chaseRange) && !isHunting)
            {
                isHunting = true;
                TurnOnHuntingMode();
            }
            else if(!IsTargetInZone(target, chaseRange) && isHunting)
            {
                isHunting = false;
                TurnOnHuntingMode(false);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            ITakeDamage damageable = collision.gameObject.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(DamageAmount);
            Debug.Log($"{DamageAmount} damage from enemy");

            TurnOnHuntingMode(false);

            Die();
        }

        private void TurnOnHuntingMode(bool isHuntingMode = true)
        {
            if (isHuntingMode)
            {
                EnemyMovementController.SetBehaviorHunter(target.gameObject);
            }
            else
            {
                EnemyMovementController.SetBehaviorIdle();
            }
        }
    }
}