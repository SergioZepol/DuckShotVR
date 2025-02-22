using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Reloj : MonoBehaviour
{
    public TextScript textscript; //--------------------pruebas

    bool selected=false;
        
    private InputAction aumentarTiempo;                                       //control por oculus
    [Space] [SerializeField] private InputActionAsset myActionsAsset;

    SkinnedMeshRenderer[] meshRenderer;       //para alterar el aspecto visual al hacer hover
    GameObject reloj;

    private void Start()
    {
        aumentarTiempo = myActionsAsset.FindAction("XRI Left/Tiempo");             //control por oculus
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        reloj = GameObject.FindGameObjectWithTag("Clock");                      //hover visuals
        meshRenderer = reloj.GetComponentsInChildren<SkinnedMeshRenderer>();

        textscript = FindObjectOfType<TextScript>(); 
    }

    private void Update()
    {
        if (selected &&(Input.GetKeyDown(KeyCode.P) || aumentarTiempo.WasPerformedThisFrame()))       //control por oculus            
        {
            textscript.aumentarCrono(); 
            Destroy(gameObject, 0.05f);          //destruye la bala cuando pasa el tiempo
        }
    }
    public void SetSelectedOn()     //controlar si el objeto esta agarrado
    {
        selected = true;
    }
    public void SetSelectedOff()
    {
        selected = false;
    }

    public void hoverVisualOn()
    {
        if (!selected)
            foreach (SkinnedMeshRenderer mesh in meshRenderer)
            { mesh.material.color = Color.green;
                Debug.Log("on");
            }
    }
    public void hoverVisualOff()
    {
        foreach (SkinnedMeshRenderer mesh in meshRenderer)
            { mesh.material.color = Color.white;
            Debug.Log("off");
            }
            
    }

}

