using Assets.Scripts.Data;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected UnitBase parentUnit;

        protected float timeFireRate;
        protected float damage;

        protected bool _isShooting = false;
        protected virtual void SetSettings(WeaponData weaponSetting)
        {
            timeFireRate = weaponSetting.TimeFireRate;
            damage = weaponSetting.AttackDamage;
        }

        public abstract void StartShoot();
        public abstract void StopShoot();

        public virtual void SetInfoBaseUnit(UnitBase unitBase)
        {
            parentUnit = unitBase;
        }
    }
}
