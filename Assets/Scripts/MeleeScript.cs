using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    public delegate void PunchDamage();
    public static event PunchDamage OnPunchDamage;
    public void Punch()
    {
        print("I just fucked you up lol");
        OnPunchDamage.Invoke();
        
    }
    public delegate void StopLockon();
    public static event StopLockon OnStopLockon;

    public void NoLockon()
    {
        print("NoLockon");
        OnStopLockon.Invoke();
    }
    public delegate void EnterLockon();
    public static event EnterLockon OnEnterLockon;

    public void EnterLockonFucntion()
    {
        print("Lockon");
        OnEnterLockon.Invoke();
    }
}
