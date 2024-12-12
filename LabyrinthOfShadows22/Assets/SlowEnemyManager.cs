using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Enemies;
using UnityEngine;

public class SlowEnemyManager : MonoBehaviour
{

    [SerializeField]
    private SlowEnemy _slowEnemy;

    [SerializeField]
    private float _spawnTime = 5f;


    private void Start()
    {
        StartCoroutine(SpawnEnemyInTime());
    }

    private IEnumerator SpawnEnemyInTime()
    {
        yield return new WaitForSeconds(_spawnTime);
        _slowEnemy.gameObject.SetActive(true);
    }
}
