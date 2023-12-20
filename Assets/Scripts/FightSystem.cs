using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSystem : MonoBehaviour
{
    private Rigidbody PhysicBody;

    public float PunchForce;
    
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

    }
    public void PunchGo()
    {
        PhysicBody.AddForce(Vector3.forward * PunchForce, ForceMode.Impulse);
    }
}
