using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Pathfinding
{
    public class Pathfinder
    {
        private GridManager _gridManager;

        public Pathfinder(GridManager gridManager)
        {
            _gridManager = gridManager;
        }

        public List<Vector2Int> FindPath(Vector2Int start, Vector2Int end)
        {
            TileNode startTileNode = _gridManager.GetNode(start);
            TileNode endTileNode = _gridManager.GetNode(end);

            if (startTileNode == null || endTileNode == null || !startTileNode.IsWalkable || !endTileNode.IsWalkable)
                return null;

            var openSet = new List<TileNode> { startTileNode };
            var closedSet = new HashSet<TileNode>();

            startTileNode.GCost = 0;
            startTileNode.HCost = Heuristic(start, end);

            while (openSet.Count > 0)
            {
                // Находим узел с наименьшим FCost
                openSet.Sort((a, b) => a.FCost.CompareTo(b.FCost));
                TileNode current = openSet[0];

                if (current == endTileNode)
                {
                    return ReconstructPath(endTileNode);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in _gridManager.GetNeighbors(current))
                {
                    if (closedSet.Contains(neighbor)) continue;

                    float tentativeG = current.GCost + 1; // стоимость шага между соседними клетками = 1
                    if (!openSet.Contains(neighbor))
                    {
                        neighbor.Parent = current;
                        neighbor.GCost = tentativeG;
                        neighbor.HCost = Heuristic(neighbor.Position, end);
                        openSet.Add(neighbor);
                    }
                    else if (tentativeG < neighbor.GCost)
                    {
                        neighbor.Parent = current;
                        neighbor.GCost = tentativeG;
                        neighbor.HCost = Heuristic(neighbor.Position, end);
                    }
                }
            }

            return null; // путь не найден
        }

        private float Heuristic(Vector2Int a, Vector2Int b)
        {
            // Манхеттенское расстояние
            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        }

        private List<Vector2Int> ReconstructPath(TileNode endTileNode)
        {
            var path = new List<Vector2Int>();
            TileNode current = endTileNode;
            
            while (current != null)
            {
                path.Add(current.Position);
                current = current.Parent;
            }
            
            path.Reverse();
            return path;
        }

    }
}