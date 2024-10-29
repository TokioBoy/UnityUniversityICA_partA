using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePlayTime : MonoBehaviour
{
    public TextMeshProUGUI gameplayTimeText;
    private bool isGameEnd = false;

    void Start()
    {
        // Check if the GameEnd scene is active
        if (SceneManager.GetActiveScene().name == "GameEnd")
        {
            isGameEnd = true;

            // Make sure the cursor is visible and unlocked
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Fix and display the elapsed time when the GameEnd scene is loaded
            DisplayFixedTime();
        }
    }

    void Update()
    {
        if (!isGameEnd)
        {
            // Increment elapsed time by the time that has passed since the last frame
            GlobalValuesManager.Instance.elapsedTime += Time.deltaTime;

            // Update and display the time in "MM:SS" format
            DisplayTime(GlobalValuesManager.Instance.elapsedTime);
        }
    }

    void DisplayTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        gameplayTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayFixedTime()
    {
        // Use the final elapsed time recorded when the game ends
        DisplayTime(GlobalValuesManager.Instance.elapsedTime);
    }
}
