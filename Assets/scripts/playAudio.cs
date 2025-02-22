using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }


    public void play()      //activa el efecto de sonido
    {
        audioSource.Play();
    }
}
