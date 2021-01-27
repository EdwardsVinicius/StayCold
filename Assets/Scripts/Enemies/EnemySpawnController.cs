using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Wave;

public class EnemySpawnController : MonoBehaviour
{
    public Wave wave;

    public GameObject[] spawnVFXSamples;
    private float spawnDelay = 1.25f;
    private float victoryDelay = 3f;
    private float waveDelay = 2f;

    private int enemiesAlive;

    private int hordeIndex;
    private int waveIndex;
    private int enemyCount;
    private float enemyTimer;
    private float hordeTimer;
    private bool hordesIsOver = false;
    private bool wavesIsOver = false;
    private bool waveInterval = false;
    public GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = 0;
        hordeIndex = 0;
        waveIndex = 0;
        enemyTimer = 0;
        hordeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveInterval) return;

        if (enemiesAlive <= 0 && hordesIsOver)
        {
            StartCoroutine(GoToNextWave());
        }

        HordeController();
    }

    private void HordeController()
    {
        Hordes hordes = wave.getHordes()[waveIndex];

        if (hordeIndex < hordes.enemies.Length)
        {
            Enemy enemies = hordes.enemies[hordeIndex];

            if (enemyCount < enemies.numberOfEnemies)
            {
                enemyTimer += Time.deltaTime;

                if (enemyTimer >= enemies.timeBetweenEnemies)
                {
                    StartCoroutine(InstantiateEnemy(enemies.enemyObject, transform.Find("Spawn" + enemies.SpawnPositionIndex).position));
                    enemyTimer = 0;
                    enemyCount++;
                }
            }
            else
            {
                hordeTimer += Time.deltaTime;

                if (hordeTimer >= enemies.timeToTheNextHorde)
                {
                    hordeTimer = 0;
                    enemyCount = 0;
                    hordeIndex++;
                }
            }
        }

        else
        {
            HordesIsOver();
        }
    }

    IEnumerator InstantiateEnemy(GameObject enemyObject, Vector3 enemyPosition)
    {
        enemiesAlive++;

        Debug.Log(enemyObject.GetComponent<EnemyStatus>().GetEnemyIDInstantiate());
        Instantiate(spawnVFXSamples[enemyObject.GetComponent<EnemyStatus>().GetEnemyIDInstantiate()], enemyPosition, Quaternion.identity);
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(enemyObject, enemyPosition, Quaternion.identity);
    }

    public void DecreaceEnemyCount()
    {
        enemiesAlive--;
    }

    private void HordesIsOver()
    {
        hordesIsOver = true;
    }

    IEnumerator GoToNextWave()
    {
        waveInterval = true;
        waveIndex++;

        yield return new WaitForSeconds(waveDelay);
        
        if(waveIndex == wave.getHordes().Length)
        {
            ActivateVictoryScreen();
        }
        else
        {
            hordeTimer = 0;
            enemyCount = 0;
            hordeIndex = 0;
            waveInterval = false;
            hordesIsOver = false;
        }
    }

    private void ActivateVictoryScreen()
    {
        victory.SetActive(true);    
        Time.timeScale = 0;
    }
}
