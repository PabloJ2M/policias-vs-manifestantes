using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _instance;
    
    [SerializeField] private Transform _pool;
    [SerializeField, Range(0, 10)] private int _poolSize;
    private GameObject[] _poolContainer;

    private void Start()
    {
        if (!_instance) return;
        _poolContainer = new GameObject[_poolSize]; 
        for (int i = 0; i < _poolSize; i++)
        {
            _poolContainer[i] = Instantiate(_instance, _pool);
            _poolContainer[i].SetActive(false);
        }
    }
    public void SpawnInPosition() => Spawn(transform.position);
    public void Spawn(Vector2 position)
    {
        for (int i = 0; i < _poolSize; i++)
        {
            if (_poolContainer[i].activeSelf) continue;
            
            _poolContainer[i].SetActive(true);
            _poolContainer[i].transform.SetPositionAndRotation(position, Quaternion.identity);
            break;
        }
    }
}