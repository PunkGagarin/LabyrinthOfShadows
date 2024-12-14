using System;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using Zenject;

public class SafeZoneManager : MonoBehaviour
{
    private List<SafeZoneView> _safeZones =  new();
    
    [Inject] private SoundManager _soundManager;

    public bool IsPlayerInSafeZone { get; private set; }

    public void RegisterZone(SafeZoneView safeZoneView)
    {
        safeZoneView.OnZonePlayerEnter += SetIsPlayerInSafeZoneToTrue;
        safeZoneView.OnZonePlayerExit += SetIsPlayerInSafeZoneToFalse;
        _safeZones.Add(safeZoneView);
    }

    private void SetIsPlayerInSafeZoneToTrue()
    {
        Debug.Log("Player in safe zone");
        _soundManager.PlayOneShotByType(GameAudioType.SafeZoneEnter, 0);
        IsPlayerInSafeZone = true;
    }

    private void SetIsPlayerInSafeZoneToFalse()
    {
        Debug.Log("Player leaved safe zone");
        IsPlayerInSafeZone = false;
    }

    private void OnDestroy()
    {
        foreach (var safeZone in _safeZones)
        {
            safeZone.OnZonePlayerEnter -= SetIsPlayerInSafeZoneToTrue;
            safeZone.OnZonePlayerExit -= SetIsPlayerInSafeZoneToFalse;
        }
    }

}