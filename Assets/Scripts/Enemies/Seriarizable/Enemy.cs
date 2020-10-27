using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy 
{
    public GameObject enemyObject;
    public int SpawnPositionIndex;
    public int numberOfEnemies;
    public float timeBetweenEnemies;
    public float timeToTheNextHorde;
}
