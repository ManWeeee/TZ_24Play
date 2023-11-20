using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeHolder : MonoBehaviour
{
    [SerializeField]
    List<Cube> cubes = new List<Cube>();
    [SerializeField]
    GameObject _cubePrefab;
    [SerializeField]
    GameObject _spawnPoint;
    GameObject _playerHolder;
    Animator _animator;

    private void Awake()
    {
        Cube[] tmp = GetComponentsInChildren<Cube>();
        foreach (Cube c in tmp)
        {
            cubes.Add(c);
        }
        _playerHolder = GameObject.FindWithTag("Player");
        _animator = _playerHolder.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(cubes.Count <= 0 && Time.timeScale == 1f) 
        {
            GameController.OnGameOver();
        }
    }

    public void Add()
    {
        _playerHolder.transform.position += new Vector3(0, _cubePrefab.GetComponent<BoxCollider>().size.y + 0.1f, 0);
        _animator.SetTrigger("Jump");
        GameObject cube = Instantiate(_cubePrefab, _spawnPoint.transform.position, _spawnPoint.transform.rotation) as GameObject;
        cube.transform.SetParent(transform, true);
        cubes.Add(cube.gameObject.GetComponent<Cube>());
        Refresh();
    }

    public void Delete(Cube cube)
    {
        cubes.Remove(cube);
    }

    public void Refresh()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            cubes[i].transform.position = cubes[0].transform.position -
                new Vector3(0, cubes[i].GetComponent<BoxCollider>().size.y * i, 0);
        }
        /*        for(int i = cubes.Count - 1; i > 0; i--)
                {
                    cubes[i].transform.position = _spawnPoint.transform.position + 
                        new Vector3(0, cubes[i].GetComponent<BoxCollider>().size.y * (cubes.Count - i), 0);
                }*/
    }
}
