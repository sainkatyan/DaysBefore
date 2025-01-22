using UnityEngine;
using UnityEngine.AI;

namespace Units.Enemy.State
{
    public class EnemyActiveAimState : EnemyState
    {
        public EnemyActiveAimState(NavMeshAgent agent, Transform target) 
            : base(agent, target) {}

        public override void Enter()
        {

        }

        public override void Exit()
        {

        }

        public override void Update()
        {
            if (Target == null) return;

            Agent.transform.LookAt(Target.transform);
        }
    }
}