using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance = null;

    private Vector3 velocity;
    private float speed = 8;

    public AudioSource jump;

    public Rigidbody rb;
    public Animator animateKyle;
    public Animator animateRex;
    public Animator animateRobin;
    public Animator animateLloyd;
    public CapsuleCollider cc;

    private float jumpHeight = 1.2f;
    public float gravity = -10;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    public bool canMove = true;
    public bool canRotate = true;

    public float numberOfJumps = 1;

    private bool isGrounded;

    private Vector2 movementInput = Vector2.zero;
    private bool jumped = false;
    private bool crouched = false;
    private bool dancing = false;

    public InputAction playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        animateKyle.GetComponent<Animator>();
        cc.GetComponent<CapsuleCollider>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // When the player move the left stick left or right
        movementInput = context.ReadValue<Vector2>(); 
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        // When the player select (Square button for PS and X button for Xbox)
        jumped = context.action.triggered;
        jumped = context.performed;

        if (context.performed && isGrounded)
        {
            // When the player jumps from the ground
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            rb.AddForce(new Vector3(0, velocity.y, 0), ForceMode.Impulse);
            jump.Play();
            numberOfJumps++;
        }
        if (context.performed && !isGrounded && numberOfJumps < 2)
        {
            // When the player preforms another jump
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            rb.AddForce(new Vector3(0, velocity.y, 0), ForceMode.Impulse);
            jump.Play();
            numberOfJumps++;

            // The player will perform a double jump animation
            animateKyle.SetTrigger("doubleJump");
            animateRex.SetTrigger("doubleJump");
            animateRobin.SetTrigger("doubleJump");
            animateLloyd.SetTrigger("doubleJump");
        }


    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        // When the player moves the left stick downwards
        crouched = context.action.triggered;
        crouched = context.performed;

    }

    public void OnDance(InputAction.CallbackContext context)
    {
       // When the player select top left trigger button
        dancing = context.action.triggered;
        dancing = context.performed;
    }

   
    void Update()
    {
        // Allows the player to move horizontal
        float moveHorizontal = movementInput.x;

        if (canMove)
        {
            // When the player is moving on the ground
            velocity.x = moveHorizontal * speed;
            animateKyle.SetFloat("speed", Mathf.Abs(moveHorizontal));
            animateRex.SetFloat("speed", Mathf.Abs(moveHorizontal));
            animateRobin.SetFloat("speed", Mathf.Abs(moveHorizontal));
            animateLloyd.SetFloat("speed", Mathf.Abs(moveHorizontal));

            // Allows the character to move left or right every per second
            transform.position += new Vector3(velocity.x, 0, 0) * Time.deltaTime;
        }
       
        // Checks the ground for the player
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animateKyle.SetBool("ground", isGrounded);
        animateRex.SetBool("ground", isGrounded);
        animateRobin.SetBool("ground", isGrounded);
        animateLloyd.SetBool("ground", isGrounded);
       
        if (isGrounded)
        {
           // If the player is on the ground or on a platform
            velocity.y = 0;
            numberOfJumps = 1;
            if (crouched)
            {
                // The player will perform the crouch animation
                animateKyle.SetBool("crouch", true);  // active the character's crouch animation
                animateRex.SetBool("crouch", true);
                animateRobin.SetBool("crouch", true);
                animateLloyd.SetBool("crouch", true);
                movementInput = Vector2.zero;
                
                // When the character is crouching, the collider gets smaller
                cc.height = 1.52f;
                cc.center = new Vector3(0f, 0.35f, 0f);
            }
            else if (!crouched)
            {
                // If the player let's go the left stick, then the player will stop crounching
                animateKyle.SetBool("crouch", false); // deactive the character's crouch animaton
                animateRex.SetBool("crouch", false);
                animateRobin.SetBool("crouch", false);
                animateLloyd.SetBool("crouch", false);

                // When the character is not crouching, the collider returns to normal
                cc.height = 2.92f;
                cc.center = new Vector3(0f, 0.69f, 0f);
            }
            if (dancing)
            {
                // The player will perform the dance animation
                animateKyle.SetBool("dance", true); // active the character's dance animation
                animateRex.SetBool("dance", true);
                animateRobin.SetBool("dance", true);
                animateLloyd.SetBool("dance", true);
                movementInput = Vector2.zero;
            }
            else if (!dancing)
            {
                // If the player let's go the left trigger, then the player will stop dancing
                animateKyle.SetBool("dance", false); // deactive the character's dance animation
                animateRex.SetBool("dance", false);
                animateRobin.SetBool("dance", false);
                animateLloyd.SetBool("dance", false);
            }
        }
        else
        {
            // When the player is currently in the air
            velocity.y += gravity * Time.deltaTime;

            // This will allow to preform the jump animation rather than still being in the crouch animation
            animateKyle.SetBool("crouch", false);
            animateRex.SetBool("crouch", false);
            animateRobin.SetBool("crouch", false);
            animateLloyd.SetBool("crouch", false);
        }

        if (moveHorizontal != 0)
        {
            if (canRotate)
            {
                // Allow the character to flip on the x axis 180 degrees
                Quaternion characterRotation = Quaternion.LookRotation(new Vector3(0, 0, moveHorizontal));
                transform.rotation = characterRotation;
            }
            

        }

       
    
    }

    void Awake()
    {
        instance = this;   
    }

    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }
}
