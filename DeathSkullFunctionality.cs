using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSkullFunctionality : MonoBehaviour
{
    public Transform player; // The player the skull will follow
    public float speed = 2.0f; // Speed at which the skull moves

    [SerializeField] private Transform respawnPoint;

    // Update is called once per frame
    void Update()
    {
        // Check if player is assigned
        if (player != null)
        {
            // Calculate the direction from the skull to the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Move the skull toward the player
            transform.position += direction * speed * Time.deltaTime;

            // Rotate the skull to face the player
            transform.LookAt(player);
        }
    }

    // This method is triggered when the skull's collider touches another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the skull collides with is the player
        if (other.CompareTag("Player"))
        {
            HandleSkullTouch();
        }
    }

    // A method that defines what happens when the skull touches the player
    void HandleSkullTouch()
    {
        Debug.Log("Skull has touched the player!");

        GlobalValuesManager.Instance.playerLives--;
        player.transform.position = respawnPoint.transform.position;

        // If the player has no lives left, restart the game
        if (GlobalValuesManager.Instance.playerLives == 0)
        {
            ExitHellScript.hasKey = false;
            SceneManager.LoadScene("TheStart");
        }
    }
}
