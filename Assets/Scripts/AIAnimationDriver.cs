using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationDriver : MonoBehaviour
{

    private NavMeshAgent agent;

    private Animator animator;
    private AI_Script ai_Script;
    public float Animfloat;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ai_Script = GetComponentInParent<AI_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        Animfloat = agent.velocity.magnitude;
        animator.SetFloat("Velocity", Animfloat);

    } 
    public void IWantToKillthingsthing()
    {
        ai_Script.ImGoingToKillMyselfNow();
    }
}
