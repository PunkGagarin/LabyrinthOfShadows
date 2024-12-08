using UnityEngine;

namespace Gameplay.Pathfinding
{
    public class TileNode
    {
        public float GCost { get; set; }
        public float HCost { get; set; }

        public float FCost => GCost + HCost;
        
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