using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField]
    private GameObject _regdollPrefab;

    private void Start()
    {
        GameController.OnGameOver += ChangeToRegdoll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            GameController.OnGameOver();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameController.OnGameOver();
        }
    }

    private void ChangeToRegdoll()
    {
        Instantiate(_regdollPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
