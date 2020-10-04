using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = null;
    [SerializeField] Transform parent = null;
    Scoreboard scoreboard;
    [SerializeField] int scorePerHit;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreboard = FindObjectOfType<Scoreboard>();
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
        scoreboard.Scorehit(scorePerHit);

        print($"Enemy hit {gameObject.name}");
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        
        Destroy(gameObject);
        
    }
}
