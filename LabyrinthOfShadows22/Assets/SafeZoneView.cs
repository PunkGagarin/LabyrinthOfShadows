using System;
using UnityEngine;
using Zenject;

public class SafeZoneView : MonoBehaviour
{
    [Inject] private SafeZoneManager _safeZoneManager;

    public event Action OnZonePlayerEnter = delegate { };
    public event Action OnZonePlayerExit = delegate { };

    private void Awake()
    {
        _safeZoneManager.RegisterZone(this);
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