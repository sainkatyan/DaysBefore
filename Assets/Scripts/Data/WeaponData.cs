using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Weapon Data Config")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float timeFireRate;
        [SerializeField] private float attackDamage;

        public float TimeFireRate
        {
            get
            {
                return timeFireRate;
            }
        }
        public float AttackDamage
        {
            get
            {
                return attackDamage;
            }
        }
    }
}