﻿using System;
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
        [SerializeField]
        private GridManager _gridManager;

        private Pathfinder _pathfinder;
        // [Inject] private GameplayManager _gameplayManager;

        [SerializeField]
        private PlayerView _playerView;


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
            _pathfinder = new Pathfinder(_gridManager);
        }

        private void Update()
        {
            // if(!_gameplayManager.IsPlaying()) return;

            //todo: округление может пойти не в ту сторону, переделать.

            if (path == null || path.Count == 0 || pathIndex >= path.Count)
            {
                playerPosition = new Vector2Int((int)_playerView.transform.position.x,
                    (int)_playerView.transform.position.y);
                currentCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
                Debug.Log($"  CurrentCell: {currentCell} PlayerPos: {playerPosition}");
                // Найти новый путь
                var pathNodes = _pathfinder.FindPath2(currentCell, playerPosition);
                path = pathNodes.Select(node => node.Position).ToList();
                pathIndex = 0;

                string finalPath = "";
                for (int index = 0; index < path.Count; index++)
                {
                    var v2 = path[index];
                    finalPath += $"index: {index} x: {v2.x} y: {v2.y}, ";
                }
                Debug.Log("finalPath: " + finalPath);
            }

            if (path != null && pathIndex < path.Count)
            {
                //todo: вынести внутрь gridManager-a
                Vector3 worldPos =
                    _gridManager.WalkableTilemap.CellToWorld(new Vector3Int(path[pathIndex].x, path[pathIndex].y, 0)) +
                    _gridManager.WalkableTilemap.cellSize * 0.5f;

                // Двигаемся к следующей точке пути
                transform.position = Vector3.MoveTowards(transform.position, worldPos, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, worldPos) < 0.01f)
                {
                    currentCell = path[pathIndex];
                    pathIndex++;
                }
            }
        }
    }
}