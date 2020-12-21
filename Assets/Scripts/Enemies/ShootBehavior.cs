using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    private Vector3 targetDirection;
    private float timeToDeactivate;

    // Update is called once per frame
    void Update()
    {
        if (targetDirection != null)
        {
            transform.position += targetDirection * Time.deltaTime;
            timeToDeactivate -= Time.deltaTime;
        }

        if (timeToDeactivate < 0)
        {
            StartDeactivation();
        }
    }

    public void DefineParams(Vector3 direction, float speed, float _timeToDeactivate)
    {
        timeToDeactivate = _timeToDeactivate;

        if (direction != null)
            targetDirection = (direction - transform.position).normalized * speed;
    }

    private void StartDeactivation()
    {
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartDeactivation();
        }
    }
}
