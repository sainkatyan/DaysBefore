using System;
using System.Collections.Generic;
using Core;
using Units.Enemy.State;
using UnityEngine;
using UnityEngine.AI;

namespace Units.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private PatrolEnemyAim patrolAim;
        private NavMeshAgent agent;
        private Transform[] patrolPoints;
        private Transform target;
        
        private Dictionary<Type, IEnemyState> behaviorsMap;
        private IEnemyState enemyCurrentState;
        private float distanceToTarget;


        public void Init(float movementSpeed)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.speed = movementSpeed;
            
            target = GameManager.Instance.player.transform;
            if (patrolAim != null)
            {
                patrolPoints = patrolAim.SetPatrolTargets();
            }
            this.InitBehaviours();
        }

        private void InitBehaviours()
        {
            behaviorsMap = new Dictionary<Type, IEnemyState>();

            behaviorsMap[typeof(EnemyStayState)] = new EnemyStayState(agent);
            behaviorsMap[typeof(EnemyHunterState)] = new EnemyHunterState(agent, target);
            behaviorsMap[typeof(EnemyPatrolState)] = new EnemyPatrolState(agent, target, patrolPoints);
            behaviorsMap[typeof(EnemyActiveAimState)] = new EnemyActiveAimState(agent, target);
        }

        public void Update()
        {
            if (enemyCurrentState != null)
            {
                enemyCurrentState.Update();
            }
        }

        private IEnemyState GetBehavior<T>() where T : IEnemyState
        {
            var type = typeof(T);
            return this.behaviorsMap[type];
        }

        private void SetBehavior(IEnemyState newbehavior)
        {
            if (enemyCurrentState != null)
                enemyCurrentState.Exit();

            enemyCurrentState = newbehavior;
            enemyCurrentState.Enter();
        }
        public void SetBehaviorIdle()
        {
            var behavior = this.GetBehavior<EnemyStayState>();
            SetBehavior(behavior);
        }

        public void SetBehaviorHunter(GameObject gameObject)
        {
            var behavior = this.GetBehavior<EnemyHunterState>();
            SetBehavior(behavior);
        }

        public void SetBehaviorPatrol()
        {
            var behavior = this.GetBehavior<EnemyPatrolState>();
            SetBehavior(behavior);
        }

        public void SetBehaviorActiveAim()
        {
            var behavior = this.GetBehavior<EnemyActiveAimState>();
            SetBehavior(behavior);
        }
    }
}