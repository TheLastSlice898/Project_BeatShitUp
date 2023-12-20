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
}
