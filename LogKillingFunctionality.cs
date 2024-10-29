using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogKillingFunctionality : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    public Transform player;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the skull collides with is the player
        if (other.CompareTag("Player"))
        {
            HandleLogTouch();
        }
    }

    // A method that defines what happens when the skull touches the player
    void HandleLogTouch()
    {
        Debug.Log("Log has touched the player!");

        GlobalValuesManager.Instance.playerLives--;
        player.transform.position = respawnPoint.transform.position;

        // If the player has no lives left, restart the game
        if (GlobalValuesManager.Instance.playerLives == 0)
        {
            ExitHellScript.hasKey = false;
            ExitEarthScript.hasKey = false;
            GlobalValuesManager.Instance.elapsedTime = 0;
            SceneManager.LoadScene("TheStart");
        }
    }
}
