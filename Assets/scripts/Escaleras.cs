using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
//script para subir las escaleras del escenario pegandote a ellas (no usando las manos para ir escalando)
public class Escaleras : MonoBehaviour
{
    public XROrigin xrOrigin; // Asigna el componente XROrigin
    public float velocidadSubida = 1.0f; // Velocidad a la que subirá el personaje

    private bool subiendoEscaleras = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider que colisionó es el del objeto XR Origin
        if (other.gameObject == xrOrigin.gameObject)
        {
            // Verifica si se está presionando la tecla "W" o el joystick de movimiento hacia adelante en los mandos
            if (Input.GetKeyDown(KeyCode.W) || Input.GetAxis("Vertical") > 0)
            {
                subiendoEscaleras = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el collider que colisionó es el del objeto XR Origin
        if (other.gameObject == xrOrigin.gameObject)
        {
            subiendoEscaleras = false;
        }
    }

    private void FixedUpdate()
    {
        if (subiendoEscaleras)
        {
            xrOrigin.transform.Translate(Vector3.up * Time.deltaTime * velocidadSubida); // Ajusta la velocidad de subida según sea necesario
            xrOrigin.transform.Translate(Vector3.forward * 0);
        }
    }
}
