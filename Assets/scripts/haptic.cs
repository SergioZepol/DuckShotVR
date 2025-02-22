using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class ActivarLinterna : MonoBehaviour
{
    void Start()
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();
        interactable.activated.AddListener(ActivateFlashlight);
    }
    void ActivateFlashlight(BaseInteractionEventArgs args)
    {
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor)
        {
            interactor.SendHapticImpulse(0.5f, 1);
        }
    }
}