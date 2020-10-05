using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = null;
    [SerializeField] Transform parent = null;
    [SerializeField] int scorePerHit;
    [SerializeField] int hits;

    [SerializeField] AudioSource destroyedAudio = null;
    Scoreboard scoreboard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();

        //destroyedAudio = GetComponent<AudioSource>();
    }

    //adds box collider dynamically to gameobject
    private void AddNonTriggerBoxCollider()
    {

        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        deathFX.SetActive(true);
    }

    //detects whether enemy has been killed
    private void OnParticleCollision(GameObject other)
    {
        print("particle hit");

        hits--;

        if (hits <=  1)
        {
            destroyedAudio.Play();
            scoreboard.Scorehit(scorePerHit);
            killEnemy();
        }

    }

    private void killEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;

        Destroy(gameObject);
    }
}
