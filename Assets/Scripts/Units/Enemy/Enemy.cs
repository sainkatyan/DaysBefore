using Assets.Scripts.Units.Enemy.State;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public abstract class Enemy : MonoBehaviour
    {
        private Dictionary<Type, IEnemyState> behaviorsMap;
        private IEnemyState enemyCurrentState;

        public void Init(IEnemyState enemyState)
        {
            this.InitBehaviours();
            this.SetBehavior(enemyState);
            gameObject.SetActive(true);
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
            this.SetBehavior(behavior);
        }

        public void Die()
        {
            gameObject.SetActive(false);
        }
    }
}