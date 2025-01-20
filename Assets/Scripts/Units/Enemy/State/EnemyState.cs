using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public abstract class EnemyState : IEnemyState
    {
        protected Enemy enemy;
        protected NavMeshAgent agent;
        protected Transform target;
        protected Transform[] wayPoints;
        protected float chaseRange;

        public EnemyState( NavMeshAgent agent)
        {
            this.agent = agent;
        }

        public EnemyState(NavMeshAgent agent, Transform target = null)
        {
            this.agent = agent;
            this.target = target;
        }

        public EnemyState( NavMeshAgent agent, Transform target, Transform[] wayPoints = null)
        {
            this.agent = agent;
            this.target = target;
            this.wayPoints = wayPoints;
        }

        public EnemyState(Enemy enemy, NavMeshAgent agent, Transform target, float chaseRange)
        {
            this.enemy = enemy;
            this.agent = agent;
            this.target = target;
            this.chaseRange = chaseRange;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}