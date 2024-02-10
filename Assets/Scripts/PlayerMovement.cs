using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    CharacterController characterController;
    public Transform cam;

    Animator animator;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;

    PlayerStats playerStats;
    SpeedSpell speedSpell;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float movementSpeed;

    public float gravity = -9.81f;
    public Vector3 velocity;


    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        speedSpell = GetComponent<SpeedSpell>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        //Cursor.visible = false;
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        
        movementSpeed = playerStats.playerBaseSpeed * speedSpell.speedModifyer;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
            //Debug.Log(characterController.velocity.magnitude);
            

            if(movementSpeed > 5f) {
                animator.SetBool("Walk", false);
                animator.SetBool("Run", true);
            }

            else
            {
                animator.SetBool("Run", false);
                animator.SetBool("Walk", true);
            }
        }

        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
        }
        

  

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }


        if (!isGrounded)
        {
            animator.SetBool("Jump", true);
        }

        else
        {
            animator.SetBool("Jump", false);
        }



        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        //Debug.Log(characterController.velocity.magnitude);


    }


}
