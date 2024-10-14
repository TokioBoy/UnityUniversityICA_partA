using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeSelector : MonoBehaviour
{
    // Enum to represent different game modes
    public enum GameMode { Easy, Medium, Hard }

    // Variable to hold the current game mode
    public GameMode currentGameMode;

    // Reference to buttons
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public void Start()
    {
        // Assign button click listeners
        easyButton.onClick.AddListener(SetEasyMode);
        mediumButton.onClick.AddListener(SetMediumMode);
        hardButton.onClick.AddListener(SetHardMode);

    }

    // Methods to set game modes and hide buttons
    public void SetEasyMode()
    {
        currentGameMode = GameMode.Easy;
        GlobalValuesManager.Instance.playerLives = 3;
        Debug.Log("Game Mode set to Easy.");
        HideButtons();
        SceneManager.LoadScene("Testing");
    }

    public void SetMediumMode()
    {
        GlobalValuesManager.Instance.playerLives = 2;
        currentGameMode = GameMode.Medium;
        Debug.Log("Game Mode set to Medium.");
        HideButtons();
        SceneManager.LoadScene("Testing");
    }

    public void SetHardMode()
    {
        GlobalValuesManager.Instance.playerLives = 1;
        currentGameMode = GameMode.Hard;
        Debug.Log("Game Mode set to Hard.");
        HideButtons();
        SceneManager.LoadScene("Testing");
    }

    // Method to hide all buttons
    private void HideButtons()
    {
        easyButton.gameObject.SetActive(false);
        mediumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
    }
}
