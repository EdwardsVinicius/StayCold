﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float health = 10;

    private AudioSource[] sounds;

    private void Start()
    {
        sounds = GetComponents<AudioSource>();
    }
    private void Update()
    {
        if(health <= 0)
        {
            var enemy = FindObjectOfType<ScoreController>();
            enemy.scoreUp(1);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Hitbox")
        {
            //sounds[0].Play();
            LoseHealth(10);
        }

    }

    private void LoseHealth(int amount)
    {
        health -= amount;
    }
}
