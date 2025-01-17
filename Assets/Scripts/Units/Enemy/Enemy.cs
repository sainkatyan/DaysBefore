using Assets.Scripts.Data;
using Assets.Scripts.Units.Player;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyTypesData enemyData;

        private EnemyMovementController enemyMovementController;
        private float damageAmount;

        private void Awake()
        {
            enemyMovementController = GetComponent<EnemyMovementController>();
            enemyMovementController.Init(this, enemyData);
        }

        private void Start()
        {
            SetEnemyData();
        }

        private void SetEnemyData()
        {
            damageAmount = enemyData.patrolEnemy.damage;
        }

        private void OnCollisionEnter(Collision collision)
        {
            ITakeDamage damageable = collision.gameObject.GetComponent<ITakeDamage>();
            if (damageable == null) return;

            damageable.TakeDamage(damageAmount);
            Debug.Log($"{damageAmount} damage from enemy");

            Die();
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}