using Assets.Scripts.Core;
using Assets.Scripts.Units.Enemy.State;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        [SerializeField] private PatrolEnemyAim patrolAim;
        private Enemy enemy;
        private NavMeshAgent agent;
        private Transform[] patrolPoints;
        private Transform target;
    
        private Dictionary<Type, IEnemyState> behaviorsMap;
        private IEnemyState enemyCurrentState;
        private float distanceToTarget;
        private float chaseRange;


        public void Init(Enemy enemy)
        {
            this.enemy = enemy;
            agent = GetComponent<NavMeshAgent>();
            target = GameManager.Instance.player.transform;
            if (patrolAim != null)
            {
                patrolPoints = patrolAim.SetPatrolTargets();
            }

            SetMovemetSpeed();

            this.InitBehaviours();
        }

        private void SetMovemetSpeed()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }

            agent.speed = GameManager.Instance.enemyData.patrolEnemy.speed; //have to change
            chaseRange = GameManager.Instance.enemyData.patrolEnemy.chaseRange;
        }

        private void InitBehaviours()
        {
            behaviorsMap = new Dictionary<Type, IEnemyState>();

            this.behaviorsMap[typeof(EnemyStayState)] = new EnemyStayState(agent);
            this.behaviorsMap[typeof(EnemyHunterState)] = new EnemyHunterState(agent, target);
            this.behaviorsMap[typeof(EnemyPatrolState)] = new EnemyPatrolState(agent, target, patrolPoints);
            this.behaviorsMap[typeof(EnemyActiveAimState)] = new EnemyActiveAimState(agent, target);
        }

        public void Update()
        {
            if (this.enemyCurrentState != null)
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
            if (this.enemyCurrentState != null)
                enemyCurrentState.Exit();

            this.enemyCurrentState = newbehavior;
            this.enemyCurrentState.Enter();
        }
        public void SetBehaviorIdle()
        {
            var behavior = this.GetBehavior<EnemyStayState>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorHunter(GameObject gameObject)
        {
            var behavior = this.GetBehavior<EnemyHunterState>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorPatrol()
        {
            var behavior = this.GetBehavior<EnemyPatrolState>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorActiveAim()
        {
            var behavior = this.GetBehavior<EnemyActiveAimState>();
            this.SetBehavior(behavior);
        }

        public bool IsNewState(IEnemyState newbehavior)
        {
            return (this.enemyCurrentState != null && this.enemyCurrentState != newbehavior);
        }
    }
}