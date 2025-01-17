using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Enemy Data Config")]
    public class EnemyData : ScriptableObject
    {
        public bool isShooting = false;
        public float speed;
        public float damage;
    }
}
