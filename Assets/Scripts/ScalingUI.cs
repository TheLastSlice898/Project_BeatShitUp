using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingUI : MonoBehaviour
{
    public GameObject ThePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        float targetangle = transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0f,targetangle,0f);
    }
}
