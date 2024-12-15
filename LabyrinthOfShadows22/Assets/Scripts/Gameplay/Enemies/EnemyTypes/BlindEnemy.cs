using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class BlindEnemy : BaseEnemy
    {
        [SerializeField]
        private List<Transform> _patrolWayPoints;

        private bool hasBuiltPath = false;

        protected void Start()
        {
            //лютый костыль чтобы не разбираться с порядком вызова
            StartCoroutine(BuildPathFromWayPointsAndSelf());
        }

        private IEnumerator BuildPathFromWayPointsAndSelf()
        {
            yield return new WaitForSeconds(0.5f);
            _path = new List<Vector2Int>();

            _path.Add(_currentCell);
            foreach (var wayPoint in _patrolWayPoints)
            {
                Vector2Int waypointPos = new Vector2Int((int)wayPoint.position.x, (int)wayPoint.position.y);
                _path.Add(_gridManager.GetNode(waypointPos).Position);
            }
        }

        protected override void Update()
        {
            if (!_gameplayManager.IsGamePlaying())
                return;

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