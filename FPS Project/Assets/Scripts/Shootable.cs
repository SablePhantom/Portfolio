using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shootable : MonoBehaviour
{
    [SerializeField] private int health = 10;
    [SerializeField] private int maxHitsBeforeReset = 10; // Number of hits before resetting
    private int hitCount = 0;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb; // Reference to the Rigidbody

    private void Start()
    {
        // Cache the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Store the original position and rotation
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    public void SetHealth(int damage)
    {
        health -= damage;
        hitCount++;

        // Stop it from sliding right after taking a hit
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Check if the hit count exceeds the limit
        if (hitCount > maxHitsBeforeReset)
        {
            ResetToOriginalPosition();
        }
    }

    private void ResetToOriginalPosition()
    {
        // Instantly stop all physics movement and spinning
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Reset the position and rotation of the enemy
        transform.position = originalPosition;
        transform.rotation = originalRotation;

        // Reset health or other properties if needed
        health = 10; // Reset health to default value
        hitCount = 0; // Reset hit count
    }
}