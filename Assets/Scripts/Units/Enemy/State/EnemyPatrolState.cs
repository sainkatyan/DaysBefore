using UnityEngine;
using UnityEngine.AI;

namespace Units.Enemy.State
{
    public class EnemyPatrolState : EnemyState
    {
        private const float RemainingDistance = 0.5f;
        private int destPoint = 0;

        public EnemyPatrolState(NavMeshAgent agent, Transform target, Transform[] wayPoints)
        : base(agent, target, wayPoints) { }

        public override void Enter()
        {
            Agent.autoBraking = false;
            GotoNextPoint();
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
            if (Agent.remainingDistance < RemainingDistance)
                GotoNextPoint();
        }

        void GotoNextPoint()
        {
            if (WayPoints.Length == 0)
                return;
            Agent.destination = WayPoints[destPoint].position;
            destPoint = (destPoint + 1) % WayPoints.Length;
        }
    }
}