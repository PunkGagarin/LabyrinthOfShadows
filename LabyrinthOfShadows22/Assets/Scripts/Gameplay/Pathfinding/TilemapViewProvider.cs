using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapViewProvider : MonoBehaviour
{

    [field: SerializeField]
    public Tilemap WalkableTilemap { get; private set; }
    
    [field: SerializeField]
    public Tilemap ObstaclesTilemap { get; private set; }
    
}
