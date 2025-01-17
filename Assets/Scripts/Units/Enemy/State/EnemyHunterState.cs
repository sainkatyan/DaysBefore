using UnityEngine;
using UnityEngine.AI;

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

        public void SetWayPoints(Transform[] transforms, NavMeshAgent navMeshAgent)
        {
            throw new System.NotImplementedException();
        }
    }
}