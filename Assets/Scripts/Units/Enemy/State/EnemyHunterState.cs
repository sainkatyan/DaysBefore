using UnityEngine;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyHunterState : IEnemyState
    {
        public void Enter()
        {
            Debug.Log("enter Hunter state");
        }

        public void Exit()
        {
            Debug.Log("Exit Hunter state");
        }

        void IEnemyState.Update()
        {
            Debug.Log("Update Hunter state");
        }
    }
}