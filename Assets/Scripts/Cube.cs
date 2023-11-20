using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]
    CubeHolder _cubeHolder;

    private void Start()
    {
        _cubeHolder = GetComponentInParent<CubeHolder>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Wall>(out Wall wall))
        {
            transform.SetParent(wall.transform, true);
            _cubeHolder.Delete(this);
            Destroy(this);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<CollectibleItem>(out CollectibleItem cube))
        {
            cube.Collect();
            _cubeHolder.Add();
        }
    }
}
