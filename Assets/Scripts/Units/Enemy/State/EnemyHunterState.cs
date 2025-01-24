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
            Agent.isStopped = false;
        }

        public override void Exit()
        {
            Agent.isStopped = true;
        }

        public override void Update()
        {
            Agent.SetDestination(Target.position);
        }
    }
}