using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HellDieZone : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        // Access playerLives via the Singleton instance
        GlobalValuesManager.Instance.playerLives--;

        // Move the player to the respawn point
        if (GlobalValuesManager.Instance.playerLives != 0)
        {
            Player.transform.position = respawnPoint.transform.position;
        }
    }
}
