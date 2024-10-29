using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HellDieZone : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Access playerLives via the Singleton instance
            GlobalValuesManager.Instance.playerLives--;

            // Check player lives and handle respawn or game reset
            if (GlobalValuesManager.Instance.playerLives > 0)
            {
                StartCoroutine(RespawnWithDelay());
            }
            else
            {
                ExitHellScript.hasKey = false;
                GlobalValuesManager.Instance.elapsedTime = 0;
                SceneManager.LoadScene("TheStart");
            }
        }
    }

    private IEnumerator RespawnWithDelay()
    {
        yield return new WaitForSeconds(1.5f);
        // Move the player to the respawn point
        Player.position = respawnPoint.position;
    }
}
