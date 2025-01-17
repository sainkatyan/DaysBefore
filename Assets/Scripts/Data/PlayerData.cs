using UnityEngine;

namespace Assets.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/ Player DAta Config")]
    public class PlayerData : ScriptableObject
    {
        public int MaxHealth = 100;
        public float movementSpeed;
    }
}