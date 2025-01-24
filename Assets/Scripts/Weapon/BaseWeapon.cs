using Data;
using UnityEngine;

namespace Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected float TimeFireRate;
        protected float Damage;
        protected float BulletSpeed;

        protected bool isShooting = false;
        protected virtual void SetSettings(WeaponData weaponSetting)
        {
            TimeFireRate = weaponSetting.TimeFireRate;
            Damage = weaponSetting.AttackDamage;
            BulletSpeed = weaponSetting.BulletSpeed;
        }
        public abstract void StartShoot();
        public abstract void StopShoot();
    }
}
