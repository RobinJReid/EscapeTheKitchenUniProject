using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class thirdpersonMovement : MonoBehaviour
{
    //adapted from BRACKEYS., 2020. THIRD PERSON MOVEMENT in Unity. [online video]. May 24. Available from: https://www.youtube.com/watch?v=4HpC--2iowE&t=396s [Accessed 03 March 2024].
    public CharacterController controller;
    public Transform cam;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 50f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 velocity;

    bool isGrounded;
    public GameObject gamestate;
    private gameStateManager gameStateManager;

    Animator Anim;
    public GameObject playerObject;

    private void Start()
    {
        Debug.Log(gravity);
        gameStateManager = gamestate.GetComponent<gameStateManager>();
        Anim = playerObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!gameStateManager.isTeleporting)
        {
    isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            Debug.Log(isGrounded);

            if(isGrounded && velocity.y < 0 ) 
            {
                velocity.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(direction.magnitude > 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(Mathf.Abs(jumpHeight) * 2f * Mathf.Abs(gravity));
                Debug.Log(gravity);
            }

            if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
            {
                Debug.Log(Input.GetAxisRaw("Vertical"));
                Anim.SetBool("running", true);
            }

            if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
            {
                Debug.Log(Input.GetAxisRaw("Vertical") );
                Anim.SetBool("running", false);
            }

            velocity.y += gravity * Time.deltaTime; 
            controller.Move(velocity * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Mouse0)){
                Debug.Log("attacking!");
                Anim.SetBool("attacking", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Debug.Log("attacking stopped");
                Anim.SetBool("attacking", false);
            }


        }

        
    }
}
