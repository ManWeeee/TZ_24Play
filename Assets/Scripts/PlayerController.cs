using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float _xBorder;
    [SerializeField]
    float _speed;
    Vector3 _touchPosition;
    float _deadZone = 60f;

    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began ) {
                _touchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 currentPosition = touch.position;
                float touchDeadZone = (currentPosition - _touchPosition).magnitude;
                if (currentPosition.x < _touchPosition.x && touchDeadZone > _deadZone)
                {
                    transform.Translate(Vector3.left * _speed * Time.deltaTime);
                }
                else if (currentPosition.x > _touchPosition.x && touchDeadZone > _deadZone)
                {
                    transform.Translate(Vector3.right * _speed * Time.deltaTime);
                }
            }
            
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            _touchPosition = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Input.mousePosition;
            float touchDeadZone = (currentPosition - _touchPosition).magnitude;
            if (currentPosition.x < _touchPosition.x && touchDeadZone > _deadZone)
            {
                transform.Translate(Vector3.left * _speed * Time.deltaTime);
            }
            else if(currentPosition.x > _touchPosition.x && touchDeadZone > _deadZone)
            {
                transform.Translate(Vector3.right * _speed * Time.deltaTime);
            }
        }

#endif
        if (transform.position.x < -_xBorder)
        {
            transform.position = new Vector3(-_xBorder, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > _xBorder)
        {
            transform.position = new Vector3(_xBorder, transform.position.y, transform.position.z);
        }
    }
}
