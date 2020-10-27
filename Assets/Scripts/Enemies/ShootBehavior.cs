using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    private Vector3 targetDirection;
    private float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (targetDirection != null)
        {
            transform.position += targetDirection * Time.deltaTime;
            timeToDestroy -= Time.deltaTime;
        }

        if (timeToDestroy < 0)
        {
            StartDestroy();
        }
    }

    public void DefineParams(Vector3 direction, float speed, float _timeToDestroy)
    {
        timeToDestroy = _timeToDestroy;

        if (direction != null)
            targetDirection = (direction - transform.position).normalized * speed;
    }

    private void StartDestroy()
    {
        Destroy(gameObject);
    }
}
