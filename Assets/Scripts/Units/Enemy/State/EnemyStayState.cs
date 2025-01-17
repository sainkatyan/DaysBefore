using UnityEngine;
using UnityEngine.AI;

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

        public void SetWayPoints(Transform[] transforms, NavMeshAgent navMeshAgent)
        {
            throw new System.NotImplementedException();
        }

        void IEnemyState.Update()
        {
            Debug.Log("Update Idle state");
        }
    }
}