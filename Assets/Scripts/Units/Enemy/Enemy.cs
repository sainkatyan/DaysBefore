using Core;
using Data;
using UnityEngine;

namespace Units.Enemy
{
    public abstract class Enemy : UnitBase
    {
        public EnemyTypes enemyType;
        private EnemyTypesData enemyTypesData;
        protected EnemyMovementController EnemyMovementController;
        protected float DamageAmount { get; private set; }
        protected float DetectionRange { get; private set; }
        private float movementSpeed;
        
        protected virtual void Start()
        {
            enemyTypesData = GameManager.Instance.enemyData; 
            GetEnemyData();
            EnemyMovementController = GetComponent<EnemyMovementController>();
            EnemyMovementController.Init(movementSpeed);

            Initialize();
        }

        private void Initialize()
        {
            PerformAction();
        }

        protected abstract void PerformAction();

        private void GetEnemyData()
        {
            switch (enemyType)
            {
                case EnemyTypes.Stay:
                    DamageAmount = enemyTypesData.stayEnemy.damage;
                    movementSpeed = enemyTypesData.stayEnemy.movementSpeed;
                    DetectionRange = enemyTypesData.stayEnemy.detectionRange;
                    return;
                case EnemyTypes.Patrol:
                    DamageAmount = enemyTypesData.patrolEnemy.damage;
                    movementSpeed = enemyTypesData.patrolEnemy.movementSpeed;
                    DetectionRange = enemyTypesData.patrolEnemy.detectionRange;
                    return;
                case EnemyTypes.Hunter:
                    DamageAmount = enemyTypesData.hunterEnemy.damage;
                    movementSpeed = enemyTypesData.hunterEnemy.movementSpeed;
                    DetectionRange = enemyTypesData.hunterEnemy.detectionRange;
                    return;
                default:
                    DamageAmount = enemyTypesData.stayEnemy.damage;
                    movementSpeed = enemyTypesData.stayEnemy.movementSpeed;
                    DetectionRange = enemyTypesData.stayEnemy.detectionRange;
                    return;
            }
        }

        protected bool IsTargetInSight(Transform target, float chaseRange)
        {
            if (!IsTargetInZone(target, chaseRange)) return false;
            return IsTargetInView(target, chaseRange);
        }

        protected bool IsTargetInZone(Transform target, float chaseRange)
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