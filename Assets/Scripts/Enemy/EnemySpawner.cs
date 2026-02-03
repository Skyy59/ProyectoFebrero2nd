using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] _enemyPrefabs;
    
    [Header("Attributes")]
    [SerializeField] private int _spawnedEnemies = 8;
    [SerializeField] private float _enemiesperSecond = 0.5f;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _scalingFactor = 0.75f;

    private int _currentWave = 1;
    private int _enemiesLeftSpawn;
    private int _enemiesAlive;
    private float _timeSinceSpawn;
    private bool _isSpawning = false;


    private void Start()
    {
        StartWave();
    }


    void Update()
    {
        if (!_isSpawning) return;

        _timeSinceSpawn += Time.deltaTime;

        if(_timeSinceSpawn >= (1f/ _enemiesperSecond) && _enemiesLeftSpawn > 0)
        {
            SpawnEnemy();
            _enemiesLeftSpawn--;
            _enemiesAlive++;
            _timeSinceSpawn = 0f;
        }
    }

    private void StartWave()
    {
        _isSpawning = true;
        _enemiesLeftSpawn = EnemiesPerWave();
    }

    private void SpawnEnemy()
    {
        GameObject prefabtoSpawn = _enemyPrefabs[0];
        Instantiate(prefabtoSpawn, LevelManager.Instance.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(_spawnedEnemies * Mathf.Pow(_currentWave, _scalingFactor));
    }
}
