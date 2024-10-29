using System.Collections;
using UnityEngine;

public class KeyToWin : MonoBehaviour
{
    private bool hasBeenCollected = false; // Flag to check if the object has already been collected

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered is the player and the object hasn't been collected yet
        if (other.CompareTag("Player") && !hasBeenCollected)
        {
            hasBeenCollected = true; // Set the flag to prevent further collections

            // Set the hasKey flag in ExitHeavenScript to true
            ExitHeavenScript.hasKey = true;
            GlobalValuesManager.Instance.playerLives++;

            // Start coroutine to hide the game object after a delay
            StartCoroutine(HideObjectAfterDelay());
        }
    }

    private IEnumerator HideObjectAfterDelay()
    {
        // Wait for 0.6 seconds
        yield return new WaitForSeconds(0.6f);

        // Hide or deactivate the current game object (this key object)
        gameObject.SetActive(false);
    }
}
