using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    public delegate void SwitchTargetObject(Transform ene);
    public static event SwitchTargetObject OnSwitchTargetObject;
    private Rigidbody PhysicBody;

    public float PunchForce;
    public GameObject CurrentTarget;
    public List<GameObject> Targets;
    private void OnEnable() => MeleeScript.OnPunchDamage += PunchGo;
    private void OnDisable() => MeleeScript.OnPunchDamage -= PunchGo;

    // Start is called before the first frame update
    void Start()
    {
        PhysicBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Targets.Count == 0)
        {
            if (Camera.main.GetComponentInChildren<Animator>().GetBool("LockOn") == true)
            {
                Camera.main.GetComponentInChildren<Animator>().SetBool("LockOn", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Q) && Targets.Count != 0)
        {

            if (Targets == null)
            {

            }
            else
            {
                CurrentTarget = Targets[0];
                gameObject.GetComponent<PlayerController>().TargetedEnemy = CurrentTarget.transform;
                gameObject.GetComponentInChildren<MeleeScript>().EnterLockonFucntion();
                OnSwitchTargetObject.Invoke(CurrentTarget.transform);
            }
        }

    }
    public void PunchGo()
    {
        PhysicBody.AddForce(gameObject.GetComponentInChildren<Animator>().gameObject.transform.forward * PunchForce, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            if (other.gameObject == Targets.Contains(other.gameObject))
            {
                print("Its the same enemny");
            }
            else
            {
                Targets.Add(other.gameObject);
            }
            
        }

       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Targets.Remove(other.gameObject);
        }
        
    }
}
