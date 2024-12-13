 using UnityEngine;

public class LevelViewProvider : MonoBehaviour
{

    [field: SerializeField]
    public Transform PlayerSpawnPoint { get; private set; }
    
    [field: SerializeField]
    public LevelBoundsView LevelBoundsView { get; private set; }
    
    [field: SerializeField]
    public TilemapViewProvider TilemapViewProvider { get; private set; }
}
