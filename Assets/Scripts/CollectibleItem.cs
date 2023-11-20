using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _collectionEffect;
    [SerializeField]
    Billboard _pointS;
    float _offset = 2f;
    float _delayTimeToDestroy = 1f;

    public void Collect()
    {
        ParticleSystem sys = Instantiate(_collectionEffect, transform.position, transform.rotation);
        Instantiate(_pointS, transform.position + Vector3.up * _offset, transform.rotation);
        Destroy(sys, _delayTimeToDestroy);
        Destroy(gameObject);
    }
}
