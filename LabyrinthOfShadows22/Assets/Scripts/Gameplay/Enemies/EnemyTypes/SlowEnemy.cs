using UnityEngine;

namespace Gameplay.Enemies
{
    //todo: remake this class
    public class SlowEnemy : Enemy
    {
        
        protected override void Update()
        {
            if (!_gameplayManager.IsGamePlaying())
                return;

            SearchPathToPlayerWithDealy();
            MoveToNextPoint();
        }
        
        protected override void Awake()
        {
            _currentCell = _currentCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
            _spawnPointCell = new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        protected virtual void OnDestroy()
        {
        }
    }
}