using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrail : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _trailParticle;
    float _trailDurationTime = 0.7f;
    bool _isPlaycingTrail;

    void Update()
    {
        if (!_isPlaycingTrail)
        {
            _isPlaycingTrail = true;
            StartCoroutine(MakeTrails());
        }
    }

    private IEnumerator MakeTrails()
    {
        ParticleSystem trail = Instantiate(_trailParticle, transform.localPosition, _trailParticle.transform.rotation);
        yield return new WaitForSeconds(0.04f);
        StartCoroutine(DestroyTrail(trail));
        _isPlaycingTrail = false;
        
    }
    
    IEnumerator DestroyTrail(ParticleSystem trail)
    {
        yield return new WaitForSeconds(_trailDurationTime);
        Destroy(trail.gameObject);
    }
}
