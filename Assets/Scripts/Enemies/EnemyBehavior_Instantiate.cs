using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Instantiate : MonoBehaviour
{
    [Header("Object")]
    public int poolSize;
    public GameObject enemyDrop;

    [Header("Instance Type")]
    public bool normal = false;
    public bool bomb = false;

    [Header("Common Shoot Parameters")]
    public bool seekNearestPlayer;
    public float speed;
    public float timeToDeactivate;
    public bool applyGravity;

    [Header("Bomb Parameters")]
    public int projectileNumber;
    public float projectileLifetime;
    public float speedProjectiles;

    private Queue<GameObject> poolFire;

    private void Start()
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyDrop);
            objectPool.Enqueue(obj);
        }

        poolFire = objectPool;
    }

    public void TriggerFireInstance()
    {
        GameObject nextShoot = poolFire.Dequeue();

        nextShoot.SetActive(true);
        nextShoot.transform.position = transform.position;

        nextShoot.GetComponent<Rigidbody>().isKinematic = applyGravity ? false : true;

        Transform direction = seekNearestPlayer ? ClosestPlayer() : transform;

        if (direction != null)
        {
            if (normal)
                nextShoot.GetComponent<ShootBehavior>().DefineParams(direction.position, speed, timeToDeactivate);

            else if (bomb)
                nextShoot.GetComponent<BombBehavior>().DefineParams(direction.position, speed, timeToDeactivate, projectileNumber, projectileLifetime, speedProjectiles);
        }

        poolFire.Enqueue(nextShoot);
    }

    private Transform ClosestPlayer()
    {
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players == null)
            return null;

        GameObject closest = null;
        float distance = Mathf.Infinity;

        Vector3 position = transform.position;

        foreach (GameObject player in players)
        {
            Vector3 diff = player.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = player;
                distance = curDistance;
            }
        }

        return closest.transform;
    }
}
