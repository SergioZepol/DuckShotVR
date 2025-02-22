using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempo = 5;

    private void Awake()
    {
        Destroy(gameObject, tiempo);          //destruye la bala cuando pasa el tiempo
    }

    private void OnCollisionEnter(Collision collision)  
    {
        //Destroy(collision.gameObject);        //destruye el objeto con el que colisiona
        Destroy(gameObject);                //destruye la propia bala
    }

}
