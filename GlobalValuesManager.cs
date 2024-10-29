using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValuesManager : MonoBehaviour
{
    // Static instance for Singleton pattern
    public static GlobalValuesManager Instance;

    // Example variables
    public int playerLives = -1;
    public bool lose = false;
    public float elapsedTime;

    void Awake()
    {
        // Ensure that there is only one instance of this object
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevents this object from being destroyed when loading a new scene
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy the new one
        }
    }
}
