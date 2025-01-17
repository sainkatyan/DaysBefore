using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Enemy Type Config")]
    public class EnemyTypesData : ScriptableObject
    {
        public EnemyData patrolEnemy;
        public EnemyData hunterEnemy;
        public EnemyData stayEnemy;
    }
}