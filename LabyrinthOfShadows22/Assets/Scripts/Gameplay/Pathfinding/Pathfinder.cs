using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay.Pathfinding
{
    public class Pathfinder
    {
        [Inject] private GridManager _gridManager;

        private const int DIAGONAL_COST = 14;
        private const int STRAIGHT_COST = 10;

        public List<TileNode> FindPath2(Vector2Int start, Vector2Int end)
        {
            TileNode startTileNode = _gridManager.GetNode(start);
            TileNode endTileNode = _gridManager.GetNode(end);

            if (startTileNode == null || endTileNode == null || !startTileNode.IsWalkable || !endTileNode.IsWalkable)
                return null;

            var openList = new List<TileNode> { startTileNode };
            var closedSet = new HashSet<TileNode>();

            _gridManager.PrepareNodesForSearch();

            startTileNode.GCost = 0;
            startTileNode.HCost = Heuristic(startTileNode.Position, endTileNode.Position);


            while (openList.Count > 0)
            {
                TileNode current = FindLowestFCostNode(openList);
                if (HasReachFinalNode(current, endTileNode))
                    return CalculatePath(endTileNode);

                openList.Remove(current);
                closedSet.Add(current);

                var neighbours = _gridManager.GetNeighbours(current);

                foreach (var neighbourNode in neighbours)
                {
                    if (closedSet.Contains(neighbourNode))
                        continue;

                    if (!neighbourNode.IsWalkable)
                    {
                        closedSet.Add(neighbourNode);
                        continue;
                    }

                    int tentativeGCost = current.GCost + Heuristic(current.Position, neighbourNode.Position);

                    //ответить на вопрос зачем нам нужен этот иф ????
                    if (tentativeGCost < neighbourNode.GCost)
                    {
                        neighbourNode.Parent = current;
                        neighbourNode.GCost = tentativeGCost;
                        neighbourNode.HCost = Heuristic(neighbourNode.Position, endTileNode.Position);
                        if (!openList.Contains(neighbourNode))
                            openList.Add(neighbourNode);
                    }
                }
            }
            return null;
        }

        private List<TileNode> CalculatePath(TileNode endTileNode)
        {
            List<TileNode> path = new List<TileNode>();
            TileNode currentNode = endTileNode;
            path.Add(endTileNode);

            while (currentNode.Parent != null)
            {
                path.Add(currentNode.Parent);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        private static bool HasReachFinalNode(TileNode current, TileNode endTileNode)
        {
            return current == endTileNode;
        }

        private TileNode FindLowestFCostNode(List<TileNode> openList)
        {
            //Sort хуже по стоимости? Форич по идее дешевле
            openList.Sort((a, b) => a.FCost.CompareTo(b.FCost));
            return openList[0];
        }

        // private float Heuristic(Vector2Int a, Vector2Int b)
        // {
        //     return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
        // }

        private int Heuristic(Vector2Int a, Vector2Int b)
        {
            int xDistance = Mathf.Abs(a.x - b.x);
            int yDistance = Mathf.Abs(a.y - b.y);
            int remaining = Mathf.Abs(xDistance - yDistance);

            return DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + STRAIGHT_COST * remaining;
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