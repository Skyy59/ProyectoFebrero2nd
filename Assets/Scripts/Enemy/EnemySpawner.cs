
using System.Collections;
using UnityEngine;

using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] private WaveSO currentWave;
    [SerializeField] private WaveSO[] waves;
    
    [Header("Attributes")]
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    

    private int _enemyIndex;
    private int _waveIndex = 0;
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
        currentWave = waves[0];
        StartCoroutine(StartWave());
        
    }


    void Update()
    {
        if (!_isSpawning) return;
 
        _timeSinceSpawn += Time.deltaTime;

        if(_timeSinceSpawn >= (1f/ enemiesPerSecond) && _enemiesLeftSpawn > 0)
        {
            SpawnWaveEnemy();
           
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
        _enemiesLeftSpawn = currentWave.enemies.Length;
    }

    private void EndWave()
    {
        _isSpawning = false;
        _timeSinceSpawn = 0f;
        _enemyIndex = 0;
        WaveIncrement();
        
    }

    private void EnemyKilled()
    {
        _enemiesAlive--;
    }
    
    private void WaveIncrement()
    {
        
        // _waveIndex = _waveIndex + 1 >= waves.Length ? -1 : _waveIndex++;

        if (_waveIndex + 1 >= waves.Length)
        {
            _waveIndex = -1;
        }
        else
        {
            _waveIndex++;
        }
        currentWave = waves[_waveIndex];
        
        if (_waveIndex == -1)
        {
            //Termina el juego
        }
        else
        {
            StartCoroutine(StartWave());
        }
        
    }

    private void SpawnWaveEnemy()
    {
        if (_enemyIndex >= currentWave.enemies.Length) return;
        
        EnemyMovement currentEnemy = currentWave.enemies[_enemyIndex];
        Instantiate(currentEnemy, LevelManager.Instance.startPoint.position, Quaternion.identity);
        _enemyIndex++;
        
        _enemiesLeftSpawn--;
        _enemiesAlive++;
        _timeSinceSpawn = 0f;

    }
}
