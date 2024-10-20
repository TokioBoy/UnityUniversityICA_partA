using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingPlatformImidiatly : MonoBehaviour
{


    // This method is called when another collider enters the trigger collider attached to the GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // remove the platform after a delay
            Destroy(gameObject);
        }
    }
}

