using Assets.Scripts.Core;
using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class ShooterEnemy : Enemy
    {
        public Transform WeaponPivot;
        public WeaponController weaponController;
        private Transform target;
        private float chaseRange;
        private float distanceToTarget;
        private bool isShooting;

        public override void PerformAction()
        {
            enemyMovementController.SetBehaviorIdle();

            weaponController = GetComponent<WeaponController>();
            isShooting = false;
            target = GameManager.Instance.player.transform;
            chaseRange = GameManager.Instance.enemyData.stayEnemy.chaseRange;
        }
        public void Update()
        {
            if (target == null) return; //check player's dead for deACTIVATE

            if (IsPlayerInViewZoneAndIldleState())
            {
                ActivateShootMode();
            }
            else if (isShooting)
            {
                DeActivateShootMode();
            }
        }

        private bool IsPlayerInViewZoneAndIldleState()
        {
            distanceToTarget = Vector3.Distance(this.transform.position, target.position);
            return distanceToTarget <= chaseRange && !isShooting;
        }

        private void ActivateShootMode()
        {
            isShooting = true;
            weaponController.StartShoot();

            enemyMovementController.SetBehaviorActiveAim();
        }

        private void DeActivateShootMode()
        {
            isShooting = false;
            weaponController.StopShoot();

            enemyMovementController.SetBehaviorIdle();
        }
    }
}