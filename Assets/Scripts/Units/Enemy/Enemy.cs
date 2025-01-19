using Assets.Scripts.Core;
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyTypesData enemyData;
        public EnemyTypes enemyType;
        protected EnemyMovementController enemyMovementController;
        public float DamageAmount { get; private set;}

        protected virtual void Start()
        {
            enemyMovementController = GetComponent<EnemyMovementController>();
            enemyMovementController.Init(this, enemyData);

            Initialize();
        }

        public virtual void Initialize()
        {
            PerformAction();
            DamageAmount = SetTakingDamage();
        }

        public abstract void PerformAction();

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

        public bool IsTargetInSight(Transform target)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.up, out hit))
            {
                if (hit.transform == target)
                {
                    Debug.Log($"IsTargetInSight true");
                    return true;
                }
                Debug.Log($"IsTargetInSight false");
            }
            Debug.Log($"IsTargetInSight false");

            return false;
        }

        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}