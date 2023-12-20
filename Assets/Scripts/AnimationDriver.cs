using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDriver : MonoBehaviour
{
    public Animator DaAmimator;
    public GameObject PlayerScript;

    public float PunchWeight;
    public bool FightSystem;
    // Start is called before the first frame update
    void Start()
    {
        DaAmimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {




        bool DoubleJumpo = PlayerScript.GetComponent<PlayerController>().DoubleJump;
        bool IsGrounded = PlayerScript.GetComponent<PlayerController>().IsGrounded;
        bool IsSprinting = PlayerScript.GetComponent<PlayerController>().IsSprinting;
        bool IsMoving = PlayerScript.GetComponent<PlayerController>().IsMoving;

        float AnimMoveX = PlayerScript.GetComponent<PlayerController>().playerMovementInput.x;
        float AnimMoveZ = PlayerScript.GetComponent<PlayerController>().playerMovementInput.z;

        if (IsSprinting)
        {
            AnimMoveZ *= 2;
            AnimMoveX *= 2;
        }




        float SpeedMulti = PlayerScript.GetComponent<PlayerController>().SpeedMulti;
        DaAmimator.SetLayerWeight(1, PunchWeight);
        DaAmimator.SetBool("IsMoving", IsMoving);
        DaAmimator.SetBool("IsSprinting", IsSprinting);
        DaAmimator.SetFloat("MoveX", AnimMoveX);
        DaAmimator.SetFloat("MoveZ", AnimMoveZ);
        DaAmimator.SetBool("IsGrounded", IsGrounded);
        DaAmimator.SetFloat("SpeedMulti", SpeedMulti);

       

        if (Input.GetKeyDown(KeyCode.Space) && DoubleJumpo)
        {
            DaAmimator.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !DoubleJumpo)
        {
            DaAmimator.SetTrigger("DoubleJump");
        }

        //if (IsMoving && FightSystem)
        //{
        //    PunchWeight = Mathf.Lerp(1,0, 1);
        //}

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FightSystem = true;
            DaAmimator.SetTrigger("Punch");
            PunchWeight = Mathf.Lerp(0,1, 1);
            
        }


       

       

    }
}
