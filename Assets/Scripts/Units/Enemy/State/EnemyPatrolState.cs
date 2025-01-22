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
            Debug.Log("enter Patrol state");

            //SetMovementParameters();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            Agent.autoBraking = false;

            GotoNextPoint();
        }

        public override void Exit()
        {
            Debug.Log("Exit Patrol state");
        }


        public override void Update()
        {
            Debug.Log("Update Patrol state");

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (Agent.remainingDistance < RemainingDistance)
                GotoNextPoint();
        }

        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (WayPoints.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            Agent.destination = WayPoints[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % WayPoints.Length;
        }
    }
}