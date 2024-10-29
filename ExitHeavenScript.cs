using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHeavenScript : MonoBehaviour
{
    public static bool hasKey = false;
    void OnTriggerEnter(Collider collider)
    {
        if (hasKey == true)
        {
            SceneManager.LoadScene("GameEnd");
        }
    }
}
