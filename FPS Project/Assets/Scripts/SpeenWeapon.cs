using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeenWeapon : MonoBehaviour
{
    [Header("Spin Settings")]
    public float spinSpeed = 15.0f; // Degrees per second

    public enum RotationSpace
    {
        Local,
        Global
    }
    public RotationSpace rotationSpace = RotationSpace.Local;

    [Header("Hover Settings")]
    public float hoverAmplitude = 0.2f; // How high/low it moves
    public float hoverFrequency = 1.0f; // How fast it hovers up and down

    private Vector3 startPosition;

    // Allows the pickup script to pause this script's movement
    [HideInInspector] public bool isPaused = false;

    void Start()
    {
        // Store the original position of the object
        startPosition = transform.position;
    }

    void Update()
    {
        // Stop moving if the pickup script tells us it's collected
        if (isPaused) return;

        // Handle Horizontal Spinning
        float rotationAmount = spinSpeed * Time.deltaTime;

        if (rotationSpace == RotationSpace.Local)
        {
            // Spins around its own local Y axis
            transform.Rotate(0, rotationAmount, 0, Space.Self);
        }
        else
        {
            // Spins around the global world Y axis
            transform.Rotate(0, rotationAmount, 0, Space.World);
        }

        // Handle Floating / Hovering
        // Mathf.Sin calculates a smooth wave based on elapsed time
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        
        // Update position while maintaining X and Z coordinates
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
    // Allows the pickup script to update the center anchor on respawn
    public void ResetStartPosition(float customYPosition)
    {
        startPosition = new Vector3(transform.position.x, customYPosition, transform.position.z);
    }

}
