using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDriver : MonoBehaviour
{
    public Animator DaAmimator;
    public GameObject PlayerScript;

    public float PunchWeight;
    
    // Start is called before the first frame update
    void Start()
    {
        DaAmimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {



        
        bool IsGrounded = PlayerScript.GetComponent<PlayerController>().IsGrounded;
        bool IsSprinting = PlayerScript.GetComponent<PlayerController>().IsSprinting;
        bool IsMoving = PlayerScript.GetComponent<PlayerController>().IsMoving;

        float AnimMoveX = PlayerScript.GetComponent<PlayerController>().playerMovementInput.x;
        float AnimMoveY = PlayerScript.GetComponent<PlayerController>().playerMovementInput.z;

        DaAmimator.SetLayerWeight(1, PunchWeight);
        DaAmimator.SetBool("IsMoving", IsMoving);
        DaAmimator.SetBool("IsSprinting", IsSprinting);
        DaAmimator.SetFloat("MoveX", AnimMoveX);
        DaAmimator.SetFloat("MoveY", AnimMoveY);
        DaAmimator.SetBool("IsGrounded", IsGrounded);

        if (IsSprinting)
        {
            PunchWeight = IsSprinting? 0 : 1;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DaAmimator.SetTrigger("Jump");
        }

        //if (IsMoving && FightSystem)
        //{
        //    PunchWeight = Mathf.Lerp(1,0, 1);
        //}

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DaAmimator.SetTrigger("Punch");
            PunchWeight = Mathf.Lerp(0,1, 1);
            
        }


       

       

    }
}
