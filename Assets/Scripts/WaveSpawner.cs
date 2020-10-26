using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public enum GameState
{
    PLAYERSTATE,
    ENEMYSTATE
}

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    public float timeBetweenWaves = 5.0f;

    private int nextWaveIndex = 0;
    private SpawnState state = SpawnState.COUNTING;
    private float search = 1.0f;
    private float waveCountDown;

    void Start()
    {
        waveCountDown = timeBetweenWaves;
    }

    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            // --------- if enemies are alive ------------ //
            if(!EnemyIsAlive())
            {
                // ------- begin a new round -------- //
                WaveComplete();
                return;
            }
            else
            {
                return;
            }
        }

        if(waveCountDown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                // ------ start spawning wave --------- //
                StartCoroutine(SpawnWave(waves[nextWaveIndex]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }
    }

    void WaveComplete()
    {
        Debug.Log("Wave Complete!");

        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if(nextWaveIndex + 1 > waves.Length - 1)
        {
            nextWaveIndex = 0;
            Debug.Log("Completed waves! Looping...");
        }
        else
        {
            nextWaveIndex++;
        }
    }

    bool EnemyIsAlive()
    {
        search -= Time.deltaTime;

        if(search <= 0)
        {
            search = 1.0f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)// wait a certain amount of seconds before spawning.
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        // spawn things.
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1.0f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break; // returns nothing. ienum needs to return something.
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Instantiate(_enemy, transform.position, transform.rotation);
        // ------- spawn enemy! ------ //
  
    }

}
