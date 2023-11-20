using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    [SerializeField]
    GameObject _platformPrefab;
    [SerializeField]
    float _delay;
    [SerializeField]
    float _interval;

    private void Start()
    {
        InvokeRepeating("SpawnPlatform", _delay, _interval);
    }

    private void SpawnPlatform()
    {
        Instantiate(_platformPrefab, transform.position, _platformPrefab.transform.rotation);
    }
}