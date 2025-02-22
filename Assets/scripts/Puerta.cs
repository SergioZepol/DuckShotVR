using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    GameObject llave;
    private void Start()
    {
        llave = GameObject.FindGameObjectWithTag("Llave");
    }
    public void Abrir() {
            Destroy(gameObject);
            Destroy(llave);
    }
}
