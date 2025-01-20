using Assets.Scripts.Data;
using Assets.Scripts.Weapon;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public EnemyTypesData enemyData;
        public PlayerData playerData;
        public WeaponData weaponData;

        public Transform player;

        public Bullet bulletPrefub;
        public BaseWeapon weapon;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }
    }
}
