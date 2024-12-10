using System;
using UnityEngine;

namespace Gameplay.Enemies
{
    public class ZoneDetector : MonoBehaviour
    {
        private PolygonCollider2D _zoneCollider;

        public Action OnZonePlayerEnter = delegate { };
        public Action OnZonePlayerExit = delegate { };

        private void Awake()
        {
            _zoneCollider = GetComponent<PolygonCollider2D>();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            
            if (other.CompareTag("Player"))
            {
                OnZonePlayerEnter.Invoke();
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
                OnZonePlayerExit.Invoke();
        }
    }
}