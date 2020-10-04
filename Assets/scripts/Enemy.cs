using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX = null;
    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
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
        print($"Enemy hit {gameObject.name}");
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
