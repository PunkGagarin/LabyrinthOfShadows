using UnityEngine;

namespace Gameplay.Pathfinding
{
    public class TileNode
    {
        public int GCost { get; set; }
        public int HCost { get; set; }

        public int FCost => GCost + HCost;
        
        public bool IsWalkable { get; set; }
        public Vector2Int Position { get; set; }

        public TileNode Parent { get; set; }

        public TileNode(Vector2Int position, bool isWalkable)
        {
            Position = position;
            IsWalkable = isWalkable;
        }
    }
}