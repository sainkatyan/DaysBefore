using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyStayState : EnemyState
    {
        public EnemyStayState(EnemyMovementController movementController, NavMeshAgent agent, Transform target)
            : base(movementController, agent, target) { }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Update()
        {
        }
    }
}