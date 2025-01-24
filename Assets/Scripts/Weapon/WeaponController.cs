using Core;
using Units;
using UnityEngine;

namespace Weapon
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private Transform weaponPivot;
        private UnitBase parentUnit;
        private BaseWeapon Weapon { get; set; }

        private void Start()
        {
            EquipWeapon();
        }

        private void EquipWeapon()
        {
            if (Weapon != null)
            {
                Destroy(Weapon.gameObject);
            }
            
            Weapon = Instantiate(GameManager.Instance.weapon, weaponPivot.position, weaponPivot.rotation);
            Weapon.transform.SetParent(weaponPivot);
        }

        public void StartShoot()
        {
            Weapon.StartShoot();
        }
        public void StopShoot()
        {
            Weapon.StopShoot();
        }
    }
}