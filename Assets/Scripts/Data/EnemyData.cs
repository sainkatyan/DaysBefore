using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Enemy Data Config")]
    public class EnemyData : ScriptableObject
    {
        public bool isShooting = false;
        public float movementSpeed;
        public float damage;
        public float chaseRange = 10f;
        public float detectionRange = 10f;
    }
}
