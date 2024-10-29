using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthDieZone : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access playerLives via the Singleton instance
            GlobalValuesManager.Instance.playerLives--;

            // Move the player to the respawn point
            if (GlobalValuesManager.Instance.playerLives > 0)
            {
                StartCoroutine(RespawnWithDelay());
            }
            else if (GlobalValuesManager.Instance.playerLives == 0)
            {
                ExitHellScript.hasKey = false;
                ExitEarthScript.hasKey = false;
                GlobalValuesManager.Instance.elapsedTime = 0;
                SceneManager.LoadScene("TheStart");
            }
        }

        if (!other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
    private IEnumerator RespawnWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        // Move the player to the respawn point
        Player.position = respawnPoint.position;
    }
}