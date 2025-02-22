using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolloDecor : MonoBehaviour
{
    Animator animator;
    float tiempo = 0;
    bool muerto = false;
    public TextScript textscript;

    private void Start()
    {
        textscript = FindObjectOfType<TextScript>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()                   //cambios de animaciones en idle
    {
        if (!muerto)
        {
            tiempo += Time.deltaTime;

            if (tiempo <= 5 && animator.GetInteger("Estado") != 0)
                animator.SetInteger("Estado", 0);
            else if (tiempo <= 10 && animator.GetInteger("Estado") != 1)
                animator.SetInteger("Estado", 1);
            else if (tiempo <= 15 && animator.GetInteger("Estado") != 2)
                animator.SetInteger("Estado", 2);
            else
                tiempo = 0;
        }
        else if (tiempo >= 2.5f)
            Destroy(gameObject);
        else if (gameObject.transform.localScale.x > 0 && tiempo >=1.5f)
            gameObject.transform.localScale -= new Vector3(0.005f,0.005f,0.005f);       //reducir el tamaño hasta desaparecer

        tiempo += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)  
    {
        if (!muerto && collision.gameObject.tag == "semilla")
        {
            muerto = true;
            tiempo = 0;
            animator.SetInteger("Estado", 3);
            textscript.aumentarPuntuacion();        //sumar doble puntos
            textscript.aumentarPuntuacion();
        }
    }
}
