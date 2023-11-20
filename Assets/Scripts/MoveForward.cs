using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    float _speed;
    float _board = -60f;

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        if (transform.position.z < _board)
            Destroy(gameObject);
    }
}
