﻿using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    private ShipController shipController;

    [Header("General")]
    [SerializeField] float speed = 4f;
    [SerializeField] float xRange = 2f;
    [SerializeField] float yRange = 2f;

    [Header("Screen Position")]
    [SerializeField] float positionPitchFactor = 2f;
    [SerializeField] float positionYawFactor = -12f;

    [Header("Control Throw")]
    [SerializeField] float controlPitchFactor = -30f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] GameObject[] guns;
    float xThrow = 0f;
    float yThrow = 0f;
    private bool isFlightEnabled = true;

    private float firingValue;

    private void Awake()
    {
        shipController = new ShipController();

        shipController.Firing.Fire.performed += context => firingValue = context.ReadValue<float>();
        shipController.Firing.Fire.canceled += context => firingValue = 0;
    }

    private void OnEnable()
    {
        shipController.Enable();
    }

    private void OnDisable()
    {
        shipController.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlightEnabled)
        {
            ProcesssTranslation();
            ProcessRotation();
            processFiring();
        }
    }

    private void processFiring()
    {
        if (firingValue > 0)
        {
            setGunsActive(true);
        }

        else if (firingValue <= 0)
        {
            setGunsActive(false);
        }
    }

    private void setGunsActive(bool active)
    {
        foreach (GameObject gun in guns)
        {
           //gun.SetActive(active);
           var  particleSystem = gun.GetComponent<ParticleSystem>().emission;
           particleSystem.enabled = active;
        }
    }

    void OnPlayerDeath()
    {
        print("Flight controls stopped");
        isFlightEnabled = false;
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

       
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcesssTranslation()
    {
        float leftRightInput = shipController.Move.Roll.ReadValue<float>();
        float upDownnInput = shipController.Move.Pitch.ReadValue<float>();

        Vector3 currentPosition = transform.position;
        
        xThrow = shipController.Move.Roll.ReadValue<float>();
        yThrow = shipController.Move.Pitch.ReadValue<float>();

        float xOffSet = xThrow * speed * Time.deltaTime;
        float yOffSet = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); ;
    }
}
