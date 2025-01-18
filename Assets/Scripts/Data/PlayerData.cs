using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/ Player Data Config")]
    public class PlayerData : ScriptableObject
    {
        public int MaxHealth = 100;
        public float movementSpeed;
    }
}