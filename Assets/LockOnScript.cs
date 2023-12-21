using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockonScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        MeleeScript.OnStopLockon += NoLockOnFunction;
        MeleeScript.OnEnterLockon += LockOnFunction;
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
