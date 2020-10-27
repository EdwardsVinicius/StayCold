using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Instantiate : MonoBehaviour
{
    public GameObject enemyDrop;
    public float timeToDrop;

    private float timePassed = 0;

    [Header("Instance Type")]
    public bool normal = false;
    public bool bomb = false;

    [Header("Common Shoot Parameters")]
    public bool seekNearestPlayer;
    public float speed;
    public float timeToDestroy;
    public bool applyGravity;

    [Header("Bomb Parameters")]
    public int projectileNumber;
    public float projectileLifetime;
    public float speedProjectiles;

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed >= timeToDrop)
        {
            timePassed = 0f;
            GameObject newDrop = Instantiate(enemyDrop, transform.position, Quaternion.identity);
            newDrop.GetComponent<Rigidbody>().isKinematic = applyGravity ? false : true;

            Transform direction = seekNearestPlayer ? ClosestPlayer() : transform;

            if(direction != null)
            {
                if (normal)
                    newDrop.GetComponent<ShootBehavior>().DefineParams(direction.position, speed, timeToDestroy);

                else if (bomb)
                    newDrop.GetComponent<BombBehavior>().DefineParams(direction.position, speed, timeToDestroy, projectileNumber, projectileLifetime, speedProjectiles);
            }
        }
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
