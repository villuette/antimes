using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip[] audioClip;


    int i = 0;
    private void Start()
    {
        audioSource.clip = audioClip[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying == false)
        {
            audioSource.clip = audioClip[i++ % audioClip.Length];
            audioSource.Play();
        }
    }
}
