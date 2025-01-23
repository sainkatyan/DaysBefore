using Core;
using UnityEngine;
using Weapon;

namespace Units.Enemy
{
    public class ShooterEnemy : Enemy
    {
        private WeaponController weaponController;
        private Transform target;
        private float chaseRange;
        private bool isShooting = false;

        protected override void PerformAction()
        {
            EnemyMovementController.SetBehaviorIdle();

            weaponController = GetComponent<WeaponController>();
            isShooting = false;
            target = GameManager.Instance.player.transform;
            chaseRange = GameManager.Instance.enemyData.stayEnemy.chaseRange;
            
            Subscribe();
        }

        private void Subscribe()
        {
            GameManager.Instance.player.health.OnDeath += ChangeStarteAfterPlayerDeath;
        }
        
        private void UnSubscribe()
        {
            GameManager.Instance.player.health.OnDeath -= ChangeStarteAfterPlayerDeath;
        }

        private void ChangeStarteAfterPlayerDeath()
        {
            if (!isShooting) return;
            DeActivateShootMode();
        }

        public void Update()
        {
            if (!target) return; //check player's dead for deACTIVATE

            if (IsTargetInSight(target, chaseRange) && !isShooting)
            {
                ActivateShootMode();
            }
            else if (isShooting)
            {
                DeActivateShootMode();
            }
        }

        private void ActivateShootMode()
        {
            isShooting = true;
            weaponController.StartShoot();

            EnemyMovementController.SetBehaviorActiveAim();
        }

        private void DeActivateShootMode()
        {
            isShooting = false;
            weaponController.StopShoot();

            EnemyMovementController.SetBehaviorIdle();
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }
    }
}