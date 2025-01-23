using Core;
using UnityEngine;

namespace Units.Enemy
{
    public abstract class Enemy : UnitBase
    {
        public EnemyTypes enemyType;
        protected EnemyMovementController EnemyMovementController;
        protected float DamageAmount { get; private set; }

        protected virtual void Start()
        {
            EnemyMovementController = GetComponent<EnemyMovementController>();
            EnemyMovementController.Init(this);

            Initialize();
        }

        private void Initialize()
        {
            PerformAction();
            DamageAmount = SetTakingDamage();
        }

        protected abstract void PerformAction();

        private float SetTakingDamage()
        {
            switch (enemyType)
            {
                case EnemyTypes.Stay:
                    return GameManager.Instance.enemyData.stayEnemy.damage;
                case EnemyTypes.Patrol:
                    return GameManager.Instance.enemyData.patrolEnemy.damage;
                case EnemyTypes.Hunter:
                    return GameManager.Instance.enemyData.hunterEnemy.damage;
                default:
                    return GameManager.Instance.enemyData.stayEnemy.damage;
            }
        }

        protected bool IsTargetInSight(Transform target, float chaseRange)
        {
            if (!IsTargetInZone(target, chaseRange)) return false;
            return IsTargetInView(target, chaseRange);
        }

        private bool IsTargetInZone(Transform target, float chaseRange)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            return (distanceToTarget < chaseRange);
        }

        private bool IsTargetInView(Transform target, float chaseRange)
        {
            RaycastHit hit;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Physics.Raycast(transform.position + Vector3.up, directionToTarget, out hit, chaseRange))
            {
                if (hit.transform == target) return true;
            }
            return false;
        }
    }
}