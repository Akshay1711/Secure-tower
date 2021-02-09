using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawnerTwo : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public static int EnemiesAlivee = 0;
    public Wave[] waves;

    public Transform spawnPointOne;
    public Transform spawnPointTwo;

    public Transform spawnPointthree;
    public Transform spawnPointFour;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountdownText;

    public GameManager gameManager;

    private int waveIndex = 0;

    private void Start()
    {
        EnemiesAlive = 0;
        EnemiesAlivee = 0;
    }
    void Update()
    {
        if (EnemiesAlive > 0 && EnemiesAlivee > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            Debug.Log("Won the level");
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPointthree.position, spawnPointthree.rotation);
        Instantiate(enemy, spawnPointFour.position, spawnPointFour.rotation);


    }
    void SpawnEnemyTwo(GameObject enemy)
    {
        Instantiate(enemy, spawnPointOne.position, spawnPointOne.rotation);
        Instantiate(enemy, spawnPointTwo.position, spawnPointTwo.rotation);


    }

    IEnumerator SpawnWave()
    {

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count;
        EnemiesAlivee = wave.countt;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        for (int i = 0; i < wave.countt; i++)
        {
            SpawnEnemyTwo(wave.enemyTwo);
            yield return new WaitForSeconds(1f / wave.ratee);
        }
        waveIndex++;
        PlayerStats.Rounds++;
    }
}
