using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovementAnimDMG: MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public float jumpSpeed;
    private float ySpeed;
    private float originalStepOffset;

    //v5 - improve jump
    public float jumpButtonGracePeriod;
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    private CharacterController characterController;

    private Animator animator;

    [SerializeField]
    private Transform cameraTransform;

    private bool isJumping;
    private bool isGrounded;
    
    
    void Start() {

        characterController = GetComponent<CharacterController>();
        //v4 jump
        originalStepOffset = characterController.stepOffset;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //old input system
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        //Normalize diretion vector so that it has a range of 0-1
        movementDirection.Normalize();

        //v4 - Jump. update ySpeed with Gravity
        ySpeed += Physics.gravity.y * Time.deltaTime;
        //Debug.Log(ySpeed);

        //v5. improve jump
        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time; // assign time since game started
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time; // assign time since game started
        }


        //v5. improve jump replace  if (characterController.isGrounded)
        if (Time.time - lastGroundedTime <= jumpButtonGracePeriod)
        {

            characterController.stepOffset = originalStepOffset;//reset characterController stepOffset
            ySpeed = -0.5f;  //reset ySpeed 

            animator.SetBool("IsWalking", true);
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            isGrounded = true;
            isJumping = false;
            //v5. improve jump. replace  Input.GetButtonDown("Jump")
            if (Time.time - jumpButtonPressedTime <= jumpButtonGracePeriod)
            {
                ySpeed = jumpSpeed;   //apply jumpSpeed to ySpeed
                //v5. improve jump. reset nullables back to null
                // in order to avoid multiple jumps inside gracePeriod
                jumpButtonPressedTime = null;
                lastGroundedTime = null;
                animator.SetBool("IsJumping", true);
                isJumping = true;
            }
        }
        else
        {
            characterController.stepOffset = 0;
            animator.SetBool("IsWalking", false);
            isGrounded = false;

            if ((isJumping && ySpeed <0) || ySpeed < -2)
            {
                animator.SetBool("IsFalling", true);
            }
        }

        // v4 - Jump. Local var vector3 velocity
        // add ySpeed to velocity
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
       //Time.deltaTime is  required for the charControll Move method
       characterController.Move(velocity * Time.deltaTime);

        

        if (movementDirection != Vector3.zero)
        {
            //changes character to point in direction of movement. 
            animator.SetBool("IsWalking", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
    private void OnAnimatorMove()
    {
        if (isGrounded)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime;
            characterController.Move(velocity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            GameManager.health -= 1;
        }
    }
}

