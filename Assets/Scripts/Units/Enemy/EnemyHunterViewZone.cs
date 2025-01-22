using UnityEngine;

namespace Units.Enemy
{
    public class EnemyHunterViewZone : MonoBehaviour
    {
        private HunterEnemy enemy;
        private const string PlayerTag = "Player";

        public void Initialize(HunterEnemy enemy)
        {
            this.enemy = enemy;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(PlayerTag)) return;

            enemy.TurnOnHuntingMode(true, other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag(PlayerTag)) return;
            enemy.transform.LookAt(other.transform);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag(PlayerTag)) return;
            enemy.TurnOnHuntingMode(false, other.gameObject);
        }
    }
}