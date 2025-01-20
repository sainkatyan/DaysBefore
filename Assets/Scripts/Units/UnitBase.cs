using UnityEngine;

namespace Assets.Scripts.Units
{
    public abstract class UnitBase : MonoBehaviour
    {
        protected virtual void Die()
        {
            gameObject.SetActive(false);
        }
    }
}