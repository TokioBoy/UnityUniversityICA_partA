using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChangingEarthToHeaven : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ExitEarth")
        {
            SceneManager.LoadScene("Hell");
        }
    }
}
