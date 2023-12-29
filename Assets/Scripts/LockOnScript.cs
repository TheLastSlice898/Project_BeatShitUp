using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class LockonScript : MonoBehaviour
{
    public Transform enemy;
    // Start is called before the first frame update

    private void Update()
    {
        if (gameObject.GetComponentInChildren<CinemachineVirtualCamera>().LookAt == null)
        {
            gameObject.GetComponent<Animator>().SetBool("LockOn", false);
        }
    }
    private void OnEnable()
    {
        MeleeScript.OnStopLockon += NoLockOnFunction;
        MeleeScript.OnEnterLockon += LockOnFunction;
        FightSystem.OnSwitchTargetObject += SetNewTarget;
    }

    private void SetNewTarget(Transform ene)
    {
        enemy = ene;
        gameObject.GetComponentInChildren<CinemachineVirtualCamera>().LookAt = enemy;
    }

    private void OnDisable()
    {
        MeleeScript.OnStopLockon -= NoLockOnFunction;
        MeleeScript.OnEnterLockon -= LockOnFunction;
    }

        public void NoLockOnFunction()
    {
        gameObject.GetComponent<Animator>().SetBool("LockOn", false);
        
    }
    public void LockOnFunction()
    {
        
        gameObject.GetComponent<Animator>().SetBool("LockOn", true);
    }
}
