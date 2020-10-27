﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
{
    private Vector3 targetDirection;

    private float timeToExplode;
    private int projectileNumber;

    private float timeToDestroyProjectiles;
    private float speedProjectiles;

    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        timeToExplode -= Time.deltaTime;

        if (timeToExplode <= 0)
            Detonate();

        else if (targetDirection != null)
            transform.position += targetDirection * Time.deltaTime;
    }

    public void DefineParams(Vector3 direction, float speed, float _timeToDestroy, int _projectileNumber, float _timeToDestroyProjectiles, float _speedProjectiles)
    {
        timeToExplode = _timeToDestroy;
        projectileNumber = _projectileNumber;
        timeToDestroyProjectiles = _timeToDestroyProjectiles;
        speedProjectiles = _speedProjectiles;

        if(direction != null)
            targetDirection = (direction - transform.position).normalized * speed;
    }

    private void Detonate()
    {
        float projectileAngle;
        Transform projectileChild = transform.Find("ProjectileDirection");

        for (int i = 0; i < projectileNumber; i++)
        {
            projectileAngle = 360f * (i + 1) / projectileNumber;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, projectileAngle, transform.eulerAngles.z);

            Vector3 projectileDirection = projectileChild.position;

            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            newProjectile.GetComponent<ShootBehavior>().DefineParams(projectileDirection, speedProjectiles, timeToDestroyProjectiles);
        }

        StartDestroy();
    }

    private void StartDestroy()
    {
        Destroy(gameObject);
    }
}
