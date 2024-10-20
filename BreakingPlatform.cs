using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatform : MonoBehaviour
{
    // Set the delay before the platform is removed
    public float destroyDelay = 0.5f; // Adjust this value as needed

    // This method is called when another collider enters the trigger collider attached to the GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player") && GlobalValuesManager.Instance.playerLives == 1)
        {
            // Start a coroutine to remove the platform after a delay
            StartCoroutine(RemovePlatform());
        }
    }

    // Coroutine to handle the removal of the platform
    private IEnumerator RemovePlatform()
    {
        // Optionally, you can add some visual effects or sounds here

        // Wait for the specified delay
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the platform game object
        Destroy(gameObject);
    }
}
