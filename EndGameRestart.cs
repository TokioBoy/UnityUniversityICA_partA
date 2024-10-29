using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameRestart : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("TheStart");
        ExitHellScript.hasKey = false;
        ExitEarthScript.hasKey = false;
        ExitHeavenScript.hasKey = false;
        GlobalValuesManager.Instance.elapsedTime = 0;
    }
}
