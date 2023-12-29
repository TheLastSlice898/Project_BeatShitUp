using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRand : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("HitRand", Random.Range(1, 3));
    }
}
