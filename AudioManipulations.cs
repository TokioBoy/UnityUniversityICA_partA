using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManipulations : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
