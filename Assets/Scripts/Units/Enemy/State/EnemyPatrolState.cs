using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyPatrolState : IEnemyState
    {
        private const float remainingDistance = 0.5f;

        private NavMeshAgent agent;
        private Transform[] points;
        private int destPoint = 0;

        public void Enter()
        {
            Debug.Log("enter Patrol state");

            //SetMovementParameters();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            GotoNextPoint();
        }

        public void Exit()
        {
            Debug.Log("Exit Patrol state");
        }


        public void Update()
        {
            Debug.Log("Update Patrol state");

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (agent.remainingDistance < remainingDistance)
                GotoNextPoint();
        }

        void GotoNextPoint()
        {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }

        public void SetWayPoints(Transform[] transforms, NavMeshAgent navMeshAgent)
        {
            agent = navMeshAgent;
            points = transforms;
        }
    }
}