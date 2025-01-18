using Assets.Scripts.Data;
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

        private EnemyTypesData enemyData;

        private NavMeshAgent agent;
        private Transform[] patrolPoints;

        private Dictionary<Type, IEnemyState> behaviorsMap;
        private IEnemyState enemyCurrentState;


        public void Init(Enemy enemy, EnemyTypesData enemyTypesData)
        {
            agent = GetComponent<NavMeshAgent>();
            enemyData = enemyTypesData;
            SetMovemetSpeed();

            this.InitBehaviours();
        }

        private void SetMovemetSpeed()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }

            agent.speed = enemyData.patrolEnemy.speed;
        }

        private void InitBehaviours()
        {
            behaviorsMap = new Dictionary<Type, IEnemyState>();

            this.behaviorsMap[typeof(EnemyStayState)] = new EnemyStayState();
            this.behaviorsMap[typeof(EnemyHunterState)] = new EnemyHunterState();
            this.behaviorsMap[typeof(EnemyPatrolState)] = new EnemyPatrolState();
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

        public void SetBehaviorHunter()
        {
            var behavior = this.GetBehavior<EnemyHunterState>();
            this.SetBehavior(behavior);
        }

        public void SetBehaviorPatrol()
        {
            var behavior = this.GetBehavior<EnemyPatrolState>();
            patrolPoints = patrolAim.SetPatrolTargets();
            behavior.SetWayPoints(patrolPoints, agent);

            this.SetBehavior(behavior);
        }
    }
}