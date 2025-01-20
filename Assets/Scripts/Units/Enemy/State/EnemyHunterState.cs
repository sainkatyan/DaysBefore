using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyHunterState : EnemyState
    {
        public EnemyHunterState(NavMeshAgent agent, Transform target)
     : base(agent, target) { }
        public override void Enter()
        {
            Debug.Log("enter Hunter state");
            agent.isStopped = false;
        }

        public override void Exit()
        {
            Debug.Log("Exit Hunter state");
            agent.isStopped = true;
        }

        public override void Update()
        {
            Debug.Log("Update Hunter state");
            agent.SetDestination(target.position);
        }
    }
}