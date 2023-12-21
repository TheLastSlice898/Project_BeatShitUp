using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMeleeSystem : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetLayerWeight(layerIndex, 0f);
        animator.GetComponent<AnimationDriver>().PunchWeight = 0f;
        animator.GetComponent<AnimationDriver>().FightSystem = false;
    }

}
