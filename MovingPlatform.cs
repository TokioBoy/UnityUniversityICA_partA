using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Start position of the platform
    public Transform pointB; // End position of the platform
    public float speed = 2.0f; // Platform movement speed
    private Vector3 targetPosition; // Target position (either A or B)

    private bool isPlayerOnPlatform = false; // Flag to check if the player is on the platform
    private bool hasKey = false; // Flag to check if the player has the key
    private Transform playerTransform; // Reference to the player's transform
    private Vector3 lastPlatformPosition; // To track platform's movement

    private void Start()
    {
        // Initially, the platform does not move
        targetPosition = transform.position;
        lastPlatformPosition = transform.position; // Initialize last platform position
    }

    private void Update()
    {
        // Move the platform only if the player is on it and has the key
        if (isPlayerOnPlatform && hasKey)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the platform reached the target, and switch between point A and B
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = targetPosition == pointB.position ? pointA.position : pointB.position;
            }

            // Move the player with the platform based on platform movement
            if (playerTransform != null)
            {
                Vector3 platformMovement = transform.position - lastPlatformPosition;
                playerTransform.position += platformMovement; // Move player by the same amount as the platform
            }

            // Update the last platform position for the next frame
            lastPlatformPosition = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (ExitEarthScript.hasKey)
            {
                hasKey = true;
                isPlayerOnPlatform = true; // Player is on the platform, start movement
                playerTransform = other.transform; // Save reference to the player's transform
                targetPosition = pointB.position; // Start moving towards point B
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player left the platform, stop movement
            isPlayerOnPlatform = false;
            playerTransform = null; // Remove the reference to the player
        }
    }
}
