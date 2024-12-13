using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

public class CinfinerPolygonSetter : MonoBehaviour
{
    [Inject] private LevelViewProvider _levelViewProvider;


    private void Awake()
    {
        var confiner = GetComponent<CinemachineConfiner2D>();
        confiner.m_BoundingShape2D = _levelViewProvider.LevelBoundsView.LevelBounds;
    }
}
