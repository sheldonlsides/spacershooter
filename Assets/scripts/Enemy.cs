using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = null;
    [SerializeField] Transform parent = null;
<<<<<<< HEAD
    [SerializeField] int scorePerHit;
    [SerializeField] int hits;

    [SerializeField] AudioSource destroyedAudio = null;
    Scoreboard scoreboard;
=======
    Scoreboard scoreboard;
    [SerializeField] int scorePerHit;
>>>>>>> e04bd8583c65fdd619b72c9a342d1bd30fb5bd44

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
<<<<<<< HEAD

        //destroyedAudio = GetComponent<AudioSource>();
=======
>>>>>>> e04bd8583c65fdd619b72c9a342d1bd30fb5bd44
    }

    //adds box collider dynamically to gameobject
    private void AddNonTriggerBoxCollider()
    {
<<<<<<< HEAD

=======
>>>>>>> e04bd8583c65fdd619b72c9a342d1bd30fb5bd44
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

        deathFX.SetActive(true);
    }

    //detects whether enemy has been killed
    private void OnParticleCollision(GameObject other)
    {
<<<<<<< HEAD
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
=======
        scoreboard.Scorehit(scorePerHit);

        print($"Enemy hit {gameObject.name}");
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        
        Destroy(gameObject);
        
>>>>>>> e04bd8583c65fdd619b72c9a342d1bd30fb5bd44
    }
}
