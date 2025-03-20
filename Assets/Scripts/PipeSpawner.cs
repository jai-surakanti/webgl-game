using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    private float _maxTime = 1.5f;
    private float _heightRange = 0.45f;
    public GameObject _pipe;
    private float _timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange), 0);
        GameObject pipe = Instantiate(_pipe, spawnPosition, Quaternion.identity);
        Destroy(pipe, 10f);
    }
}
