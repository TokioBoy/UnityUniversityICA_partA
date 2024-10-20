using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyToHeaven : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered is the player
        if (other.CompareTag("Player"))
        {
            // Set the hasKey flag in ExitHellScript to true
            ExitEarthScript.hasKey = true;
            GlobalValuesManager.Instance.playerLives++;

            // Hide the current game object (this key object)
            gameObject.SetActive(false);
        }
    }
}
