using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform Enemy;
        public int amount;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountdown;

    private SpawnState state = SpawnState.COUNTING;

     void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

     void Update()
    {
        if (waveCountdown <= 0)
        {
           if(state != SpawnState.SPAWNING)
            {
                StartCoroutine( SpawnWave ( waves [ nextWave ]));
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.amount; i++)
        {
            SpawnEnemy(_wave.Enemy);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy" + _enemy.name);
    }
}
