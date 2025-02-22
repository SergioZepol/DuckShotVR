using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    Animator animator;
    public TextScript textscript;
    public int vida = 3;
    public bool muerto = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        textscript = FindObjectOfType<TextScript>();
    }
    private void OnCollisionEnter(Collision collision)
    {   
        // si colisiona con una semilla-bala
       
        if (collision.gameObject.tag == "semilla")  //si colisiona con una semilla-bala
        {
            if (vida > 0)
            {
                animator.SetInteger("Estado", 1);    //recibe daño
                vida -= 1;
                //textscript.aumentarPuntuacion(); //debug
                //textscript.puntuacion = textscript.puntuacion + 1; //debug
            }
            if (vida <= 0)
            {
                animator.SetInteger("Estado", 2);   //muerto
                if (muerto == false) {
                textscript.aumentarPuntuacion();
                }
                muerto = true;
            }            
        }
    }
}
