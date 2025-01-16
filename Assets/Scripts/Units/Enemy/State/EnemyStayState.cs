using UnityEngine;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyStayState : IEnemyState
    {
        public void Enter()
        {
            Debug.Log("enter Idle state");
        }

        public void Exit()
        {
            Debug.Log("Exit Idle state");
        }

        void IEnemyState.Update()
        {
            Debug.Log("Update Idle state");
        }
    }
}