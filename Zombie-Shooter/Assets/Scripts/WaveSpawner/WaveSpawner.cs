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
    private float waveCountdown;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

     void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

     void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // Check if enemies is still alive
            if(!EnemyIsAlive())
            {
                //Begin a new round
                Debug.Log("Wave Completed");
                return;
            } else
            {
                return;
            }
        }

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

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        Debug.Log("Spawning Wave;" + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.amount; i++)
        {
            SpawnEnemy(_wave.Enemy);
            yield return new WaitForSeconds( 1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        //Spawn enemy
        Debug.Log("Spawning Enemy" + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
       
    }
}
