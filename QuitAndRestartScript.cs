using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitAndRestartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
 
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            ExitHellScript.hasKey = false;
            ExitEarthScript.hasKey = false;
            ExitHeavenScript.hasKey = false;
            GlobalValuesManager.Instance.elapsedTime = 0;
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.R)){
            SceneManager.LoadScene("TheStart");
            ExitHellScript.hasKey = false;
            ExitEarthScript.hasKey = false;
            ExitHeavenScript.hasKey = false;
            GlobalValuesManager.Instance.elapsedTime = 0;
        }
    }
}
