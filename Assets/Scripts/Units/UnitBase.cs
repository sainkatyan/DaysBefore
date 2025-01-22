using UnityEngine;

namespace Units
{
    public abstract class UnitBase : MonoBehaviour
    {
        public bool isDead = false;
        protected virtual void Die()
        {
            isDead = true;
            gameObject.SetActive(false);
        }
    }
}