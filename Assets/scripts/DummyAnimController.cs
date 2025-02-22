using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAnimController : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)  
    {
        animator.SetInteger("Estado", 0);   //volver a Idle cuando acabe la animación
    }
}
