using UnityEngine;
using UnityEngine.AI;

namespace Units.Enemy.State
{
    public class EnemyHunterState : EnemyState
    {
        public EnemyHunterState(NavMeshAgent agent, Transform target)
     : base(agent, target) { }
        public override void Enter()
        {
            Debug.Log("enter Hunter state");
            Agent.isStopped = false;
        }

        public override void Exit()
        {
            Debug.Log("Exit Hunter state");
            Agent.isStopped = true;
        }

        public override void Update()
        {
            Debug.Log("Update Hunter state");
            Agent.SetDestination(Target.position);
        }
    }
}