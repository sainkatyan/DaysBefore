using Assets.Scripts.Core;
using Assets.Scripts.Units;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform weaponPivot;
        private UnitBase parentUnit;
        public BaseWeapon weapon { get; private set; }

        private void Start()
        {
            EquipWeapon();
        }

        public void Init(UnitBase unitBase)
        {
            parentUnit = unitBase;
        }

        private void EquipWeapon()
        {
            if (weapon != null)
            {
                Destroy(weapon.gameObject);
            }

            weapon = Instantiate(GameManager.Instance.weapon, weaponPivot.position, weaponPivot.rotation);
            weapon.transform.SetParent(weaponPivot);
            weapon.SetInfoBaseUnit(parentUnit);
        }

        public void StartShoot()
        {
            weapon.StartShoot();
        }
        public void StopShoot()
        {
            weapon.StopShoot();
        }
    }
}