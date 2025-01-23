using UnityEngine;

namespace Units
{
    public abstract class UnitBase : MonoBehaviour
    {
        protected void Die()
        {
            gameObject.SetActive(false);
        }
    }
}