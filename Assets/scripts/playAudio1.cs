using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudio1 : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        GameObject ARM;
        ARM = GameObject.FindGameObjectWithTag("ARM");
        audioSource = ARM.GetComponent<AudioSource>(); 
    }


    public void play()      //activa el efecto de sonido
    {
        audioSource.Play();
    }
}
