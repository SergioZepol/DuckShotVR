using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Disparar : MonoBehaviour
{
    //public TextScript textscript; //--------------------pruebas

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 0.4f;       
    Animator animator;

    float timer=0;            // para control de cadencia
    bool selected=false;
        
    private InputAction disparar;                                       //control por oculus
    [Space] [SerializeField] private InputActionAsset myActionsAsset;

    SkinnedMeshRenderer meshRenderer;       //para alterar el aspecto visual al hacer hover

    

    private void Start()
    {
        animator = GetComponent<Animator>();

        disparar = myActionsAsset.FindAction("XRI Right/Disparar");             //control por oculus
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        
        interactable.activated.AddListener(feedbackHaptico);


    }

    private void Update()
    {
        if (selected &&(Input.GetKeyDown(KeyCode.P) || disparar.WasPerformedThisFrame()) && timer > 0.50f)       //control por oculus            
        {
            animator.SetBool("Disparar", true);
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawnPoint.forward * bulletSpeed);
            timer = 0;
        }
        if (timer < 0.51f)
        { timer += Time.deltaTime; }
                
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
        if(!selected)
            meshRenderer.material.color = Color.green;
    }
    public void hoverVisualOff()
    {
        meshRenderer.material.color = Color.white;
    }

    void feedbackHaptico(BaseInteractionEventArgs args)         //mandar feedback haptico 
    {
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor)
        {
            //Debug.Log("Feedback");                    //para pruebas con el simulador
            interactor.SendHapticImpulse(0.5f, 1);
        }
    }

}

