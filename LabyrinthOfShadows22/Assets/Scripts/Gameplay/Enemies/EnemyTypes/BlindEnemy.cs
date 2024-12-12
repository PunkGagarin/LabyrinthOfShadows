using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class BlindEnemy : BaseEnemy
    {
        private List<Transform> _patrolWayPoints;
        
        protected override void Update()
        {
            base.Update();
            MoveToNextPoint();
        }

        protected override void ReachPointLogic()
        {
            base.ReachPointLogic();
            
            if (HasReachFinalPoint())
                RevertPath();
            
        }

        private bool HasReachFinalPoint()
        {
            return _currentCell == _path[^1];
        }

        private void RevertPath()
        {
            _path.Reverse();
            _pathIndex = 0;
        }
    }
}