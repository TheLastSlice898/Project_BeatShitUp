using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHitBoxes : StateMachineBehaviour
{
    public GameObject colliders;

    private GameObject theinstante;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        theinstante = Instantiate(colliders, animator.transform);


    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(theinstante);
    }
}
