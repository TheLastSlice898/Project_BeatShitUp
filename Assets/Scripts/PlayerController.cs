using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerController : MonoBehaviour
{
    public float MouseSesitivity = 5, PlayerSesitivity = 15, jumpForce = 10, CurrentSpeed, WalkSpeed = 2.2f, SprintSpeed = 10;

    public float SpeedMulti = 1, JumpMulti = 1;
    public Vector3 playerMovementInput;
    public Vector3 MouseInput;
    

    private Rigidbody RbPlayer;
    private Transform cam;

    public bool IsGrounded , IsMoving, IsSprinting, DoubleJump;

    public float PunchForce;


    float xRotation;
    float yRotation;

    void Awake()
    {
        RbPlayer = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update()
    {

        
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * (100 * MouseSesitivity);
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * (100 * MouseSesitivity);
        //playerBody.velocity = new Vector3 (moveX, playerBody.velocity.z, moveY);

        xRotation -= MouseY;
        yRotation += MouseX;

        //makes the rotation between -90 and 90 degrees 
        yRotation = Mathf.Clamp(xRotation, -56f, 56f);

        //using the mouse input to make a vector 3 to rotate the player left and right 
        MouseInput = new Vector3(0f, MouseX, 0f);

        //sets teh player input into a vector 3
        playerMovementInput = new Vector3(moveX, 0f, moveZ);

        if (playerMovementInput.magnitude >= 0.1f)
        {
            IsMoving = true;
            //grabs the angle of where the player is moving 
            float TargetAngle = Mathf.Atan2(playerMovementInput.x, playerMovementInput.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //rotates the player to this for now ;3
            gameObject.GetComponentInChildren<Animator>().gameObject.transform.rotation = Quaternion.Euler(0f, TargetAngle, 0f);

            //constructs a vector 3 from the target and multiplyin it by the forward vector
            Vector3 MovementVector = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;


            RbPlayer.velocity = new Vector3(MovementVector.x * CurrentSpeed, RbPlayer.velocity.y, MovementVector.z * CurrentSpeed);
        }
        else
        {
            IsMoving = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsSprinting = true;

            if (CurrentSpeed >= SprintSpeed)
            {
                CurrentSpeed = SprintSpeed;
            }
            else if (CurrentSpeed <= SprintSpeed)
            {
                CurrentSpeed = Mathf.Lerp(CurrentSpeed, SprintSpeed, 0.25f);
            }
        }
        else if (!Input.GetKey(KeyCode.RightShift))
        {
            IsSprinting = false;
            CurrentSpeed = Mathf.Lerp(CurrentSpeed, WalkSpeed, 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsMoving = false;
            Jump();
        }
    }
    // Update is called once per frame
    public void Jump()
    {
        if (IsGrounded)
        {
            RbPlayer.velocity = new Vector3(RbPlayer.velocity.x, jumpForce, RbPlayer.velocity.z);
            IsGrounded = false;
            DoubleJump = true;
        }
        else if (DoubleJump)
        {
            RbPlayer.velocity = new Vector3(RbPlayer.velocity.x, jumpForce, RbPlayer.velocity.z);
            DoubleJump = false;
        }
    }
    void OnCollisionEnter(Collision Collider)
    {
    if (Collider.gameObject.tag == "Floor")
        {
            IsGrounded = true;
            DoubleJump = false;
        }
    }
}