using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public Enemy[] horde;
    public GameObject[] spawnVFXSamples;
    private float spawnDelay = 1.25f;
    private float victoryDelay = 3f;

    private int enemiesAlive;

    private int hordeIndex;
    private int enemyCount;
    private float enemyTimer;
    private float hordeTimer;
    private bool hordesIsOver = false;
    public GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        enemiesAlive = 0;
        hordeIndex = 0;
        enemyTimer = 0;
        hordeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive <= 0 && hordesIsOver)
        {
            hordesIsOver = false;
            StartCoroutine(ActivateVictoryScreen());
        }

        HordeController();
    }

    private void HordeController()
    {
        if(hordeIndex < horde.Length)
        {
            if (enemyCount < horde[hordeIndex].numberOfEnemies)
            {
                enemyTimer += Time.deltaTime;

                if(enemyTimer >= horde[hordeIndex].timeBetweenEnemies)
                {
                    StartCoroutine(InstantiateEnemy(horde[hordeIndex].enemyObject, transform.Find("Spawn" + horde[hordeIndex].SpawnPositionIndex).position));
                    enemyTimer = 0;
                    enemyCount++;
                }
            }
            else
            {
                hordeTimer += Time.deltaTime;

                if(hordeTimer >= horde[hordeIndex].timeToTheNextHorde)
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

        // Debug.Log(enemyObject.GetComponent<EnemyStatus>().GetEnemyIDInstantiate());
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

    IEnumerator ActivateVictoryScreen()
    {
        yield return new WaitForSeconds(victoryDelay);
        victory.SetActive(true);    
        Time.timeScale = 0;
    }
}
