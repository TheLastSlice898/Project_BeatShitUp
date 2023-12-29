using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Script : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject ThaPlayer;
    public float health;

    public Transform[] PatrolPoints;
    public int currentwp;
    public bool patroling;

    public bool attacked;
    public bool IsDead;

    public bool agro;
    public float agrotimer = 10f;
    public float mindistance;
   

    
    // Start is called before the first frame update
    void Start()
    {
        agrotimer = 10f;
        currentwp = 0;
        
        //agent.SetDestination(PatrolPoints[currentwp].position);

    }

    // Update is called once per frame
    void Update()
    {

        if (patroling)
        {
            
            agent.SetDestination(PatrolPoints[currentwp].position);
            if (Vector3.Distance(agent.transform.position, PatrolPoints[currentwp].position) <= mindistance)
            {
                currentwp++;
            }
            if (currentwp >=PatrolPoints.Length)
            {
                currentwp = 0;
            }
        }
        else
        {
            if (Vector3.Distance(agent.transform.position, PatrolPoints[currentwp].position) <= mindistance)
            {
                agent.ResetPath();
            }
        }
        

        if (agro)
        {

            agrotimer -= Time.deltaTime;
            agent.SetDestination(ThaPlayer.transform.position);
            if (agrotimer <= 0)
            {
                agrotimer = 10f;
                agro = false;
                patroling = true;
                ThaPlayer = null;
            }
        }
        if (attacked)
        {
            agent.velocity = Vector3.zero;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //print(other.name);
        if (other.gameObject.name == "Player")
        {
            ThaPlayer = other.gameObject;
            print("I hit the player");
            patroling = false;
            agro = true;
        }

        if (other.CompareTag("HitBox"))
        {
            DamageAI();
        }
    }

    public void DamageAI()
    {
        gameObject.GetComponentInChildren<Animator>().SetTrigger("Hit");
        gameObject.GetComponentInChildren<Animator>().SetBool("Die", true);
        attacked = true;
        health = 0f;
        IsDead = true;
        
    }

   

    public void ImGoingToKillMyselfNow()
    {
        Destroy(gameObject);
    }
}
