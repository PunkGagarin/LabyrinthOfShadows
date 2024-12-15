using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay.Enemies
{
    public class Enemy : BaseEnemy, IStoppable
    {
        [Inject] private SafeZoneManager _safeZoneManager;

        [SerializeField]
        private ZoneDetector _zoneDetector;

        private float _searchPathDelay = 0.5f;

        private float _currentSearchPath = 5f;

        private Vector2Int _playerPosition;

        protected bool _isChasingPlayer = false;

        public bool IsFlashlighted { get; set; } = false;

        protected override void Awake()
        {
            base.Awake();
            _zoneDetector.OnZonePlayerEnter += StartChasingPlayer;
            _zoneDetector.OnZonePlayerExit += StopChasingPlayer;
        }

        protected virtual void OnDestroy()
        {
            _zoneDetector.OnZonePlayerEnter -= StartChasingPlayer;
            _zoneDetector.OnZonePlayerExit += StopChasingPlayer;
        }

        private void StartChasingPlayer()
        {
            _isChasingPlayer = true;
        }

        private void StopChasingPlayer()
        {
            _isChasingPlayer = false;
            FindPathTo(_spawnPointCell);
        }

        protected override void Update()
        {
            base.Update();

            if (!_gameplayManager.IsGamePlaying()) return;

            if (_isChasingPlayer)
                SearchPathToPlayerWithDealy();

            //todo: dont move if we are on a spawnPoint????
            MoveToNextPoint();
        }

        protected void SearchPathToPlayerWithDealy()
        {
            if (_currentSearchPath > _searchPathDelay)
            {
                _playerPosition = new Vector2Int((int)_playerView.transform.position.x,
                    (int)_playerView.transform.position.y);

                FindPathTo(_playerPosition);
                _currentSearchPath = 0f;
            }
            _currentSearchPath += Time.deltaTime;
        }

        protected void FindPathTo(Vector2Int EndPosition)
        {
            var pathNodes = _pathfinder.FindPath2(_currentCell, EndPosition);
            if (pathNodes == null)
            {
                Debug.LogWarning("cant find path");
                _path = null;
                return;
            }
            _path = pathNodes.Select(node => node.Position).ToList();
            _pathIndex = _path.Count > 0 ? 1 : 0;
        }

        protected override bool CanMove()
        {
            bool isInSafeZone = _safeZoneManager.IsPlayerInSafeZone;
            return base.CanMove() && !isInSafeZone && !IsFlashlighted;
        }
    }
}