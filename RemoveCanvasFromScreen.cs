using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoveCanvasFromScreen : MonoBehaviour
{
    // Reference to the Canvas GameObject
    public GameObject canvas;

    // Method to remove the canvas from the screen
    public void RemoveCanvas()
    {
        if (canvas != null)
        {
            canvas.SetActive(false);
            SceneManager.LoadScene("TheStart");
        }
    }
}
