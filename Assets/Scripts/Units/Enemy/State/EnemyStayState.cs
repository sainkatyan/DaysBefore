using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyStayState : EnemyState
    {
        public EnemyStayState(NavMeshAgent agent)
            : base(agent) { }
        public override void Enter()
        {
            agent.isStopped = false;
        }

        public override void Exit()
        {

        }

        public override void Update()
        {
        }
    }
}