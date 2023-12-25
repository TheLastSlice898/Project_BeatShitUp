using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_AnimationDriver : MonoBehaviour
{

    private NavMeshAgent agent;
    private Rigidbody body;
    private Animator animator;
    public float Animfloat;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Animfloat = agent.velocity.magnitude;
        animator.SetFloat("Velocity", Animfloat);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(agent.transform.forward * -10f, ForceMode.Impulse);
        }

    }
}
