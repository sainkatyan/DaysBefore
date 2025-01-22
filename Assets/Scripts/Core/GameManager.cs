using Data;
using Units.Player;
using UnityEngine;
using Weapon;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public EnemyTypesData enemyData;
        public PlayerData playerData;
        public WeaponData weaponData;

        public Player player;

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
