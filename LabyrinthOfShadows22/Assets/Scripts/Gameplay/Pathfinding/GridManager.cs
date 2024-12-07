﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.Pathfinding
{
    public class GridManager : MonoBehaviour
    {
        [field: SerializeField]
        public Tilemap WalkableTilemap { get; private set; }

        [field: SerializeField]
        public Tilemap ObstacleTilemap { get; private set; }

        private Dictionary<Vector2Int, TileNode> _nodes = new();

        private void Awake()
        {
            //размер тайлмапы ?????
            BoundsInt bounds = WalkableTilemap.cellBounds;

            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector3Int tilePos = new Vector3Int(x, y, 0);
                    if (WalkableTilemap.HasTile(tilePos))
                    {
                        bool walkable = ObstacleTilemap == null || !ObstacleTilemap.HasTile(tilePos);
                        _nodes[new Vector2Int(x, y)] = new TileNode(new Vector2Int(x, y), walkable);
                    }
                }
            }
        }

        public TileNode GetNode(Vector2Int position)
        {
            _nodes.TryGetValue(position, out var node);
            return node;
        }

        public void PrepareNodesForSearch()
        {
            foreach (var (key, node) in _nodes)
            {
                node.GCost = Int32.MaxValue;
                node.Parent = null;
            }
        }

        public List<TileNode> GetNeighbours(TileNode node)
        {
            Vector2Int[] directions =
            {
                Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right, new(1, 1),
                new(1, -1), new(-1, 1), new(-1, -1)
            };
            var neighbours = new List<TileNode>();

            foreach (var dir in directions)
            {
                var neighborPos = node.Position + dir;
                if (_nodes.TryGetValue(neighborPos, out var neighborNode) && neighborNode.IsWalkable)
                {
                    neighbours.Add(neighborNode);
                }
            }
            return neighbours;
        }

        public IEnumerable<TileNode> GetNeighbors(TileNode node)
        {
            Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
            foreach (var dir in directions)
            {
                var neighborPos = node.Position + dir;
                if (_nodes.TryGetValue(neighborPos, out var neighbor) && neighbor.IsWalkable)
                    yield return neighbor;
            }
        }


    }
}