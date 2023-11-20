using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    GameObject[] _obstacles;
    [SerializeField]
    GameObject _cubePrefab;
    [SerializeField]
    Transform _obstacleSpawnPosition;
    GameObject _current;
    float _cubeSpawnInterval = 6f;
    float _timeSpawned;
    int numOfCubes = 3;
    Vector3 _destination;

    private void Start()
    {
        _timeSpawned = Time.time;
        _destination = new Vector3(transform.position.x, 0, transform.position.z);

        SpawnPlatform();
    }

    void Update()
    {
        if (transform.position.y < _destination.y && Time.time - _timeSpawned < 1f)
            transform.position = Vector3.Lerp(transform.position, transform.position - new Vector3(0, transform.position.y, 0), Time.time - _timeSpawned);
    }

    private void SpawnPlatform()
    {
        int randomIndex = Random.Range(0, _obstacles.Length);
        float range = GetComponent<BoxCollider>().size.x;;
        _current = _obstacles[randomIndex];
        GameObject spawned = Instantiate(_current, _obstacleSpawnPosition.position, transform.rotation);
        spawned.transform.SetParent(_obstacleSpawnPosition);
        for (int i = 0; i < numOfCubes; i++)
        {
            Vector3 spawnPoint = _obstacleSpawnPosition.transform.position - new Vector3(Random.Range(-range, range), 0, _cubeSpawnInterval * (i + 1));
            GameObject cube = Instantiate(_cubePrefab, spawnPoint, Quaternion.identity);
            cube.gameObject.transform.SetParent(transform);
        }
    }
}
