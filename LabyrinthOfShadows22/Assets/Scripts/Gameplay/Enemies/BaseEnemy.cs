using System;
using System.Collections.Generic;
using Gameplay.Managers;
using Gameplay.Pathfinding;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemies
{
    public class BaseEnemy : MonoBehaviour
    {

        [SerializeField]
        protected float _moveSpeed;
        //
        // [SerializeField]
        // protected Transform _spawnPoint;

        [SerializeField]
        protected EnemyType _type;

        [Inject] protected GridManager _gridManager;
        [Inject] protected Pathfinder _pathfinder;
        [Inject] protected GameplayManager _gameplayManager;

        protected Vector2Int _currentCell;
        protected Vector2Int _spawnPointCell;
        protected List<Vector2Int> _path;
        protected int _pathIndex = 0;

        protected virtual void Awake()
        {
            _currentCell = _currentCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
            _spawnPointCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        protected virtual void Update()
        {
            if (!_gameplayManager.IsPlaying())
                return;
        }

        protected void MoveToNextPoint()
        {
            if (_path != null && _pathIndex < _path.Count)
            {
                Vector3 worldPos = _gridManager.WalkableTilemap.CellToWorld(new Vector3Int(_path[_pathIndex].x,
                    _path[_pathIndex].y, 0)) + _gridManager.WalkableTilemap.cellSize * 0.5f;

                transform.position = Vector3.MoveTowards(transform.position,
                    worldPos, _moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, worldPos) < 0.01f)
                    ReachPointLogic();
            }
        }

        protected virtual void ReachPointLogic()
        {
            _currentCell = _path[_pathIndex];
            _pathIndex++;
        }
    }
}