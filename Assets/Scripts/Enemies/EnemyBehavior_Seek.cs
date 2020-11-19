using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Seek : MonoBehaviour
{
    public float speed;

    private Vector3 playerYCorretion;

    // Update is called once per frame
    void Update()
    {
        Transform nearestPlayer = ClosestPlayer();

        if(nearestPlayer != null)
        {
            playerYCorretion = new Vector3(nearestPlayer.position.x, transform.position.y, nearestPlayer.position.z);
            transform.position = Vector3.MoveTowards(transform.position, playerYCorretion, speed * Time.deltaTime);

            LookDirection();
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

    private void LookDirection()
    {
        Vector3 direction = (playerYCorretion - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f);

        transform.eulerAngles += new Vector3(0f, 180f, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hitbox")
        {
            ActiveDeathState();
        }
    }

    public void ActiveDeathState()
    {
        Destroy(gameObject);
    }
}
