using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/Weapon Data Config")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float timeFireRate;
        [SerializeField] private float attackDamage;

        public float TimeFireRate => timeFireRate;

        public float AttackDamage => attackDamage;
    }
}