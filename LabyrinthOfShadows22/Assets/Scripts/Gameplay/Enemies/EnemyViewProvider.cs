using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Managers;
using Gameplay.Pathfinding;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemies
{
    public class EnemyViewProvider : MonoBehaviour
    {
        [Inject] private GridManager _gridManager;
        [Inject]  private Pathfinder _pathfinder;
        [Inject]  private PlayerView _playerView;
        // [Inject] private GameplayManager _gameplayManager;

        [SerializeField]
        private float _searchPathDelay = 0.5f;
        private float _currentSearchPath = 5f;


        private float moveSpeed = 2f;
        private Vector2Int playerPosition;

        private Vector2Int currentCell;
        private List<Vector2Int> path;
        private int pathIndex = 0;

        public void SetPlayerPosition(Vector2Int playerPosition)
        {
            this.playerPosition = playerPosition;
        }

        private void Start()
        {
            currentCell = currentCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        private void Update()
        {
            // if(!_gameplayManager.IsPlaying()) return;

            if (_currentSearchPath > _searchPathDelay)
            {
                FindPath();
                _currentSearchPath = 0f;
            }
            _currentSearchPath += Time.deltaTime;

            if (path != null && pathIndex < path.Count)
            {
                //todo: вынести внутрь gridManager-a

                Vector3 worldPos =
                    _gridManager.WalkableTilemap.CellToWorld(new Vector3Int(path[pathIndex].x, path[pathIndex].y, 0)) +
                    _gridManager.WalkableTilemap.cellSize * 0.5f;
                // Debug.Log($"Set new point to move:  {worldPos}");

                // Двигаемся к следующей точке пути
                transform.position = Vector3.MoveTowards(transform.position, worldPos, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, worldPos) < 0.01f)
                {
                    currentCell = path[pathIndex];
                    pathIndex++;
                }
            }
        }

        private void FindPath()
        {
            //todo: округление может пойти не в ту сторону, переделать.
            playerPosition = new Vector2Int((int)_playerView.transform.position.x,
                (int)_playerView.transform.position.y);
            // Debug.Log($"Converting playerPos to v2int:  playerPos: {_playerView.transform.position}, " +
            //           $"converted: {playerPosition}, isWalkable: {_gridManager.CheckGridForWalkable(playerPosition)}");
            //
            // Debug.Log($"Converting our pos to v2int:  playerPos: {transform.position}, converted: {currentCell}, " +
            //           $"isWalkable: {_gridManager.CheckGridForWalkable(currentCell)}");

            // Debug.Log($"  CurrentCell: {currentCell} PlayerPos: {playerPosition}");
            // Найти новый путь

            var pathNodes = _pathfinder.FindPath2(currentCell, playerPosition);
            if (pathNodes == null)
            {
                Debug.Log("cant find path");
                path = null;
                return;
            }

            path = pathNodes.Select(node => node.Position).ToList();
            pathIndex = path.Count > 0 ? 1 : 0;

            string finalPath = "";
            for (int index = 0; index < path.Count; index++)
            {
                var v2 = path[index];
                finalPath += $"index: {index} x: {v2.x} y: {v2.y}, ";
            }
            // Debug.Log("finalPath: " + finalPath);
        }
    }
}