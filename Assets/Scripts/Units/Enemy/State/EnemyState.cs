using UnityEngine;
using UnityEngine.AI;

namespace Units.Enemy.State
{
    public abstract class EnemyState : IEnemyState
    {
        protected Enemy Enemy;
        protected readonly NavMeshAgent Agent;
        protected readonly Transform Target;
        protected readonly Transform[] WayPoints;
        protected float ChaseRange;

        protected EnemyState( NavMeshAgent agent)
        {
            Agent = agent;
        }

        protected EnemyState(NavMeshAgent agent, Transform target = null)
        {
            Agent = agent;
            Target = target;
        }

        protected EnemyState( NavMeshAgent agent, Transform target, Transform[] wayPoints = null)
        {
            Agent = agent;
            Target = target;
            WayPoints = wayPoints;
        }

        protected EnemyState(Enemy enemy, NavMeshAgent agent, Transform target, float chaseRange)
        {
            Enemy = enemy;
            Agent = agent;
            Target = target;
            ChaseRange = chaseRange;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}