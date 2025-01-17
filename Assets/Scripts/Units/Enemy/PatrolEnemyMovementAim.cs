using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Units.Enemy
{
    public class PatrolEnemyAim : MonoBehaviour
    {
        [SerializeField] private List<GameObject> targetsObjects;

        public Transform[] SetPatrolTargets()
        {
            Transform[] targets = new Transform[targetsObjects.Count];
            for (int i = 0; i < targetsObjects.Count; ++i)
            {
                targets[i] = targetsObjects[i].transform;
            }
            return targets;
        }
    }
}