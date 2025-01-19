using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public abstract class EnemyState : IEnemyState
    {
        protected EnemyMovementController movementController;
        protected NavMeshAgent agent;
        protected Transform target;
        protected Transform[] wayPoints;

        public EnemyState(EnemyMovementController movementController, NavMeshAgent agent, Transform target, Transform[] wayPoints = null)
        {
            this.movementController = movementController;
            this.agent = agent;
            this.target = target;
            this.wayPoints = wayPoints;
        }

        public EnemyState(EnemyMovementController movementController, NavMeshAgent agent, Transform target = null)
        {
            this.movementController = movementController;
            this.agent = agent;
            this.target = target;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}