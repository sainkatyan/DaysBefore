using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Units.Enemy.State
{
    public interface IEnemyState
    {

        void Enter();
        void Exit();
        void Update();
    }
}
