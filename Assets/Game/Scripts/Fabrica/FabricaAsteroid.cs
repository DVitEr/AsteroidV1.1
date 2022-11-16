using Assets.Game.Scripts.Fabrica;
using Assets.Game.Scripts.SpawnField;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FabricaAsteroid : MonoBehaviour
{
    [SerializeField] private Asteroid _asteroid;

    private int _spawnCount;

    [SerializeField] private SpawnField _field;

    public event Action<Asteroid> OnCreateAsteroid = delegate { };

    private void Start()
    {
        _spawnCount = Random.Range(9, 17);
        CreateObject();
    }

    public void CreateObject()
    {
        
        for (int i = 0; i < _spawnCount; i++)
        {
            if (_field.TryGetRandomWorldPosition(out var position))
            {
                    var asteroid = Instantiate(_asteroid, position, Quaternion.identity);
                    OnCreateAsteroid.Invoke(asteroid); 
            }
        }
    }
}
