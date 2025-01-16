using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        private Enemy enemy;
        private void Awake()
        {
            enemy = GetComponent<Enemy>();
        }

        void Update()
        {

        }
    }
}