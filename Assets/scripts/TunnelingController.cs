using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelingController : MonoBehaviour
{
    public GameObject Tunnel;
    CharacterController character;
    Material vignette;
    float velocidad,velocidadVieja;

    void Start()
    {
        Tunnel = GameObject.FindGameObjectWithTag("Tunneling");        
        character = gameObject.GetComponent<CharacterController>();
        vignette = Tunnel.GetComponent<MeshRenderer>().material;
        velocidad = character.velocity.magnitude;
    }

    void Update()
    {
        velocidadVieja = velocidad;
        if (velocidad > 3 && vignette.GetFloat("_ApertureSize") >= 0.7f)     //activar tunnel
        {
            vignette.SetFloat("_ApertureSize", vignette.GetFloat("_ApertureSize") - 0.01f);     //smooth
        }
        else if(velocidad < 3)       //desactivar tunnel
        {
            vignette.SetFloat("_ApertureSize", 1);        
        }
        
        
        velocidad = character.velocity.magnitude;   //arreglar bug que dejaba el tunneling cuando se detenía el character

    }

    private void LateUpdate()
    {
        if (velocidad == velocidadVieja)            //arreglar bug que dejaba el tunneling cuando se detenía el character
            velocidad = 0;
               
    }
}
