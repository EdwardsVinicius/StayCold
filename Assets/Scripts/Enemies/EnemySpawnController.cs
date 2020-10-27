using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public Enemy[] horde;
    private int hordeIndex;
    private int enemyCount;
    private float enemyTimer;
    private float hordeTimer;
    public GameObject victory;

    // Start is called before the first frame update
    void Start()
    {
        hordeIndex = 0;
        enemyTimer = 0;
        hordeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
                    Instantiate(horde[hordeIndex].enemyObject, transform.Find("Spawn" + horde[hordeIndex].SpawnPositionIndex).position, Quaternion.identity);
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

    private void HordesIsOver()
    {
        victory.SetActive(true);    
        // Time.timeScale = 0;
    }
}
