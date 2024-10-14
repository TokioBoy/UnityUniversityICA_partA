using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToEarth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered is the player
        if (other.CompareTag("Player"))
        {
            // Set the hasKey flag in ExitHellScript to true
            ExitHellScript.hasKey = true;

            // Hide the current game object (this key object)
            gameObject.SetActive(false);
        }
    }
}
