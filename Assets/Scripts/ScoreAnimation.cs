using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{
    [SerializeField]
    float _speed = 2f;
    [SerializeField]
    float _border = 25f;
   
    void Update()
    {
        transform.position += Vector3.up * _speed * Time.unscaledDeltaTime;
        if(transform.position.y > _border)
        {
            Destroy(gameObject);
        }
    }
}
