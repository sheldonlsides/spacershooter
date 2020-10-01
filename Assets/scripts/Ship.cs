using System;
using UnityEngine;
public class Ship : MonoBehaviour
{
    private ShipController shipController;

    [SerializeField] private  float speed = 4f;
    [SerializeField] private float xRange = 5f;
    [SerializeField] private float yRange = 3f;

    [SerializeField] private float positionPitchFactor = 2f;
    [SerializeField] private float controlPitchFactor = -30f;
    [SerializeField] private float positionYawFactor = -12f;
    [SerializeField] float controlRollFactor = -20f;

    [SerializeField] float xThrow = 0f;
    [SerializeField] float yThrow = 0f;

    private void Awake()
    {
        shipController = new ShipController();
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
        ProcesssTranslation();
        ProcessRotation();

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

        print($"Moving {leftRightInput}");

        Vector3 currentPosition = transform.position;

        xThrow = shipController.Move.Roll.ReadValue<float>();
        yThrow = shipController.Move.Pitch.ReadValue<float>();

        float xOffSet = xThrow * speed * Time.deltaTime;
        float yOffSet = yThrow * speed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffSet;
        float clampedXPos = Mathf.Clamp(rawXPos, -5f, 5f);

        float rawYPos = transform.localPosition.y + yOffSet;
        float clampedYPos = Mathf.Clamp(rawYPos, -4f, 4f);

        //currentPosition.y += clampedYPos;

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z); ;
    }
}
