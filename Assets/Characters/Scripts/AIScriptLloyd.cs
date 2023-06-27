using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScriptLloyd : MonoBehaviour
{
    private string currentState = "ChaseState";

    public Transform target;
    public float speed = 6;
    public float idleRange = 0;
    public float chaseRange = 5;
    public float attackRange = 2;
    public Animator animate;

    // AI Jump
    public Rigidbody rb;
    private Vector3 direction;
    public AudioSource jump;
    public float jumpForce = 10;
    public float gravity = -10;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeDoubleJump = true;

    private float jumpTime;

    // Hit Colliders
    public GameObject leftfootCollider;
    public GameObject rightfootCollider;
    public GameObject swordCollider;

    public bool canMove = true;
    public bool canRotate = true;

    void Start()
    {
        jumpTime = Random.Range(1, 20);
    }
    void Update()
    {
        jumpTime -= 1 * Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);

        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animate.SetBool("ground", isGrounded);


        // Makes the AI more stable
        // AI can move or rotate after the animation is done
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animate.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            canMove = true;
            canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animate.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            canMove = true;
            canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animate.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            canMove = true;
            canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animate.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            canMove = true;
            canRotate = true;
        }


        // AI can't move or rotate during the animation is being played
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            canMove = false;
            canRotate = false;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            canMove = false;
            canRotate = false;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            canMove = false;
            canRotate = false;
        }

        if (isGrounded)
        {
            direction.y = 0;
            ableToMakeDoubleJump = true;
            jumpTime = Random.Range(1, 20);
            if (jumpTime <= 0)
            {
                direction.y = jumpForce;
                rb.AddForce(new Vector3(0, direction.y, 0), ForceMode.Impulse);
                jump.Play();
                speed = 8;
                jumpTime = Random.Range(1, 20);

            }
        }
        else
        {
            // This only happens if the AI is not on the ground
            direction.y += gravity * Time.deltaTime;
            animate.SetBool("crouch", false);
            if (ableToMakeDoubleJump && jumpTime <= 0)
            {
                direction.y = jumpForce;
                rb.AddForce(new Vector3(0, direction.y, 0), ForceMode.Impulse);
                animate.SetTrigger("doubleJump");
                ableToMakeDoubleJump = false;
                jump.Play();
                jumpTime = Random.Range(1, 20);

            }
        }

        if (currentState == "IdleState")
        {
       
            if (distance < chaseRange)
                currentState = "ChaseState";

        }
        else if (currentState == "ChaseState")
        {

            // Play the run animation while the AI is in Chase State
            animate.SetTrigger("chase");
            animate.SetBool("isAttacking", false);
            leftfootCollider.SetActive(false);
            rightfootCollider.SetActive(false);
            swordCollider.SetActive(false);

            // If AI is closer to the charatcer, the state will change to attack
            if (distance < attackRange)
                currentState = "AttackState";
            if (distance < idleRange)
                currentState = "IdleState";


          if (target.position.x > transform.position.x)
            {
                // Move right while facing right
                if (canMove)
                {
                    transform.Translate(transform.right * speed * Time.deltaTime);
                }
                
                if (canRotate)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                

            }
            else if (target.position.x < transform.position.x)
            {
                // Move left while facing left
                if (canMove)
                {
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                }
                if (canRotate)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                
                
            }
        }
        else if (currentState == "AttackState")
        {
           

            // AI would perform any attacks by playing the animations
            animate.SetInteger("attackIndex", Random.Range(0, 3));
            animate.SetBool("isAttacking", true);

            // If the AI is further away from the characters, the state will change to chase
            if (distance > attackRange)
                currentState = "ChaseState";

            // Colldiers will be set to active
            leftfootCollider.SetActive(true);
            rightfootCollider.SetActive(true);
            swordCollider.SetActive(true);

        }
    }
}
