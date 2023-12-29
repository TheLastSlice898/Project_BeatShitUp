using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : StateMachineBehaviour
{

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AnimationDriver>().PlayerScript.GetComponent<PlayerController>().enabled= false;
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.GetComponent<AnimationDriver>().PlayerScript.GetComponent<PlayerController>().enabled = true;
    }
}
