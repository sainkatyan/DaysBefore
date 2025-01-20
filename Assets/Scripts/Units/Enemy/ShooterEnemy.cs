using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class ShooterEnemy : Enemy
    {
        public Transform WeaponPivot;
        public override void PerformAction()
        {
            enemyMovementController.SetBehaviorIdle();
        }
    }
}