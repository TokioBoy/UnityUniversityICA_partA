using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeSelector : MonoBehaviour
{
    public GameObject exampleOne;
    public GameObject exampleTwo;
    public GameObject exampleThree;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that triggered is the player
        if (other.CompareTag("Player"))
        {
            if(gameObject == exampleOne)
            {
                GlobalValuesManager.Instance.playerLives = 3;
                Debug.Log("Game Mode set to Easy.");
                SceneManager.LoadScene("Hell");
            }
            if (gameObject == exampleTwo)
            {
                GlobalValuesManager.Instance.playerLives = 2;
                Debug.Log("Game Mode set to Medium.");
                SceneManager.LoadScene("Hell");
            }
            if (gameObject == exampleThree)
            {
                GlobalValuesManager.Instance.playerLives = 1;
                Debug.Log("Game Mode set to Hard.");
                SceneManager.LoadScene("Hell");
            }
        }
    }
}
