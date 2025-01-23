using UnityEngine.AI;

namespace Units.Enemy.State
{
    public class EnemyStayState : EnemyState
    {
        public EnemyStayState(NavMeshAgent agent)
            : base(agent) { }
        public override void Enter()
        {
            if (Agent == null) return;
            Agent.isStopped = false;
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
        }
    }
}