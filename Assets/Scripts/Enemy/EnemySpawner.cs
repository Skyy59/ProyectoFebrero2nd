
using System.Collections;
using UnityEngine;

using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;
    
    [Header("Attributes")]
    [SerializeField] private int spawnedEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float scalingFactor = 0.75f;

    private int _currentWave = 1;
    private int _enemiesLeftSpawn;
    private int _enemiesAlive;
    private float _timeSinceSpawn;
    private bool _isSpawning;

    [Header("Events")] 
    public static UnityEvent OnEnemyKilled;

    private void Awake()
    {
        OnEnemyKilled = new UnityEvent();
        OnEnemyKilled.AddListener(EnemyKilled);
    }

    private void Start()
    {
        StartCoroutine(StartWave());
    }


    void Update()
    {
        if (!_isSpawning) return;

        _timeSinceSpawn += Time.deltaTime;

        if(_timeSinceSpawn >= (1f/ enemiesPerSecond) && _enemiesLeftSpawn > 0)
        {
            SpawnEnemy();
            _enemiesLeftSpawn--;
            _enemiesAlive++;
            _timeSinceSpawn = 0f;
        }

        if (_enemiesAlive == 0 && _enemiesLeftSpawn == 0)
        {
            EndWave(); 
        }
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(timeBetweenWaves);
        _isSpawning = true;
        _enemiesLeftSpawn = EnemiesPerWave();
    }

    private void EndWave()
    {
        _isSpawning = false;
        _timeSinceSpawn = 0f;
        _currentWave++;
        StartCoroutine(StartWave());
        
    }

    private void EnemyKilled()
    {
        _enemiesAlive--;
    }
    private void SpawnEnemy()
    {
        GameObject prefabSpawn = enemyPrefabs[0];
        Instantiate(prefabSpawn, LevelManager.Instance.startPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(spawnedEnemies * Mathf.Pow(_currentWave, scalingFactor));
    }
}
