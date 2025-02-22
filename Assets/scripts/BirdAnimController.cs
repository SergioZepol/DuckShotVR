using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimController : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if(stateInfo.IsName("Nada"))
            animator.SetBool("Disparar", false);   //volver a Idle cuando acabe la animación
    }



}
