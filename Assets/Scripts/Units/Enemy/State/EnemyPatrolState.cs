using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy.State
{
    public class EnemyPatrolState : IEnemyState
    {
        [SerializeField] private LayerMask groundMask;

        public List<Vector3> WayPoints
        {
            get
            {
                return wayPoints;
            }
            protected set
            {
                wayPoints = value;
            }
        }

        private List<Vector3> wayPoints = new List<Vector3>();

        public void Enter()
        {
            Debug.Log("enter Patrol state");
        }

        public void Exit()
        {
            Debug.Log("Exit Patrol state");
        }

        public void Update()
        {
            Debug.Log("Update Patrol state");
        }
    }
}