using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    private Vector3 targetDirection;
    private bool isExploded = false;
    [SerializeField] float timeToDeactivate;
    [SerializeField] GameObject fireballProjectile;
    [SerializeField] GameObject fireballExplosion;
    [SerializeField] float explosionDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (isExploded) return;

        if (targetDirection != null)
        {
            transform.position += targetDirection * Time.deltaTime;
            timeToDeactivate -= Time.deltaTime;
        }

        if (timeToDeactivate < 0)
        {
            StartExplosion();
        }
    }

    public void DefineParams(Vector3 direction, float speed, float _timeToDeactivate)
    {
        timeToDeactivate = _timeToDeactivate;
        
        if (direction != null)
            targetDirection = (direction - transform.position).normalized * speed;
    }

    private void StartExplosion()
    {
        isExploded = true;
        GetComponent<SphereCollider>().enabled = false;

        fireballExplosion.SetActive(true);
        fireballProjectile.SetActive(false);
    }

    public void ResetFireball()
    {
        isExploded = false;
        fireballExplosion.SetActive(false);
        fireballExplosion.GetComponent<ParticleSystem>().Clear();

        fireballProjectile.SetActive(true);
        GetComponent<SphereCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartExplosion();
        }
    }
}
