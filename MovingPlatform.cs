using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA; // Start position of the platform
    public Transform pointB; // End position of the platform
    public float speed = 2.0f; // Platform movement speed
    private Vector3 targetPosition; // Target position (either A or B)

    private void Start()
    {
        // Start moving towards point B
        targetPosition = pointB.position;
    }

    private void Update()
    {
        // Move the platform towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Check if the platform reached the target, and switch between point A and B
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Make the player a child of the platform when they step on it
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Remove the player from being a child of the platform when they step off
            other.transform.SetParent(null);
        }
    }
}
