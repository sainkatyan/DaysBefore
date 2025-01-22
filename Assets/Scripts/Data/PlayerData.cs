using UnityEngine;
using UnityEngine.Serialization;

namespace Data
{
    [CreateAssetMenu(menuName = "Data/ Player Data Config")]
    public class PlayerData : ScriptableObject
    {
        public int maxHealth = 100;
        public float movementSpeed;
    }
}