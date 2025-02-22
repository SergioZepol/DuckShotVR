using UnityEngine;
using UnityEngine.InputSystem;
public class MyActionScript : MonoBehaviour
{
    private InputAction myAction;
    [Space][SerializeField] private InputActionAsset myActionsAsset;
    void Start()
    {
        myAction = myActionsAsset.FindAction("XRI LeftHand/MiAccion");
        myAction.performed += OnMyAction;
    }
    void Update()
    {
        
    }

    void OnMyAction(InputAction.CallbackContext context)
    {
        Debug.Log("PULSADO");
    }

}
