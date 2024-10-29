using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HelpOpenAndClose : MonoBehaviour
{
    // Reference to the Canvas GameObject
    public GameObject canvasIntro;
    public GameObject canvasHelp;
    private void Start()
    {
        canvasHelp.SetActive(false);
    }
    public void OpenHelpCanvas()
    {
        if (canvasIntro != null)
        {
            canvasIntro.SetActive(false);
            canvasHelp.SetActive(true);
        }
    }
    public void CloseHelpCanvas()
    {
        if (canvasHelp != null)
        {
            canvasHelp.SetActive(false);
            canvasIntro.SetActive(true);
        }
    }
}
