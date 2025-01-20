using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
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
            if (target == null) return;

            agent.transform.LookAt(target.transform);
        }
    }
}