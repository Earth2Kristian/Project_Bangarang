using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    private string currentState = "ChaseState";

    public Transform target;
    public float speed = 6;
    public float chaseRange = 5;
    public float attackRange = 2;

    // AI Animated
    public Animator animateRex;
    public Animator animateKyle;
    public Animator animateRobin;
    public Animator animateLloyd;

    // AI Special Mechanic
    public GameObject projectiles;
    public Transform projPoint;
    public float projSpeed = 600;

    public GameObject projectiles2;
    public Transform projPoint2;
    public float projSpeed2 = 600;

    public GameObject projectiles3;
    public Transform projPoint3;
    public float projSpeed3 = 600;

    public GameObject projectiles4;
    public Transform projPoint4;
    public float projSpeed4 = 600;

    // Robin's Normal Projectiles only
    public GameObject projectilesRobin;
    public Transform projPointRobin;
    public float projSpeedRobin = 600;

    // AI Jump
    public Rigidbody rb;
    private Vector3 velocity;
    public AudioSource jump;
    public float jumpForce = 10;
    public float gravity = -10;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeDoubleJump = true;

    public float jumpTime;
    public float specialTime;
    private float nextTime;

    private float distance;

 
    // Hit Colliders
    public GameObject lefthandCollider;
    public GameObject righthandCollider;

    public GameObject lefthandCollider2;
    public GameObject righthandCollider2;
    public GameObject leftfootCollider2;
    public GameObject rightfootCollider2;

    public GameObject lefthandCollider3;
    public GameObject righthandCollider3;
    public GameObject leftfootCollider3;
    public GameObject rightfootCollider3;

    public GameObject swordCollider4;
    public GameObject leftfootCollider4;
    public GameObject rightfootCollider4;



    public bool canMove = true;
    public bool canRotate = true;

    void Start()
    {
        nextTime = 0;
        jumpTime = Random.Range(2, 9);
        specialTime = Random.Range(2, 9);

        
    }
    void Update()
    {
        

        jumpTime -= 1 * Time.deltaTime;
        specialTime -= 1 * Time.deltaTime;

      
        distance = Vector3.Distance(transform.position, target.transform.position);
         
        
        bool isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        animateRex.SetBool("ground", isGrounded);
        animateKyle.SetBool("ground", isGrounded);
        animateRobin.SetBool("ground", isGrounded);
        animateLloyd.SetBool("ground", isGrounded);


        // Makes the AI more stable
        // AI can move or rotate after the animation is done
        // Rex as AI
        if (animateRex.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animateRex.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            lefthandCollider.SetActive(false);
            righthandCollider.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateRex.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            lefthandCollider.SetActive(false);
            righthandCollider.SetActive(false);
          

            canMove = true;
            canRotate = true;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateRex.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider.SetActive(false);
            righthandCollider.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateRex.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            lefthandCollider.SetActive(false);
            righthandCollider.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.085f && animateRex.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {
            if (GameManager.Instance.p2MP >= 20)
            {
                Projectiles2();
            }

            canMove = true;
            canRotate = true;
        }

        // Kyle as AI
        if (animateKyle.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animateKyle.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            lefthandCollider2.SetActive(false);
            righthandCollider2.SetActive(false);
            leftfootCollider2.SetActive(false);
            rightfootCollider2.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateKyle.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            lefthandCollider2.SetActive(false);
            righthandCollider2.SetActive(false);
            leftfootCollider2.SetActive(false);
            rightfootCollider2.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateKyle.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider2.SetActive(false);
            righthandCollider2.SetActive(false);
            leftfootCollider2.SetActive(false);
            rightfootCollider2.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateKyle.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            lefthandCollider2.SetActive(false);
            righthandCollider2.SetActive(false);
            leftfootCollider2.SetActive(false);
            rightfootCollider2.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.06f && animateKyle.GetCurrentAnimatorStateInfo(0).IsName("fireball"))
        {
            if (GameManager.Instance.p2MP >= 20)
            {
                Projectiles();
            }

            canMove = true;
            canRotate = true;
        }

        // Robin as AI
        if (animateRobin.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animateRobin.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            lefthandCollider3.SetActive(false);
            righthandCollider3.SetActive(false);
            leftfootCollider3.SetActive(false);
            rightfootCollider3.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.55f && animateRobin.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            ProjectilesRobinAI();

            lefthandCollider3.SetActive(false);
            righthandCollider3.SetActive(false);
            leftfootCollider3.SetActive(false);
            rightfootCollider3.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateRobin.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider3.SetActive(false);
            righthandCollider3.SetActive(false);
            leftfootCollider3.SetActive(false);
            rightfootCollider3.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateRobin.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            lefthandCollider3.SetActive(false);
            righthandCollider3.SetActive(false);
            leftfootCollider3.SetActive(false);
            rightfootCollider3.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.725f && animateRobin.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {

            if (GameManager.Instance.p2MP >= 20)
            {
                Projectiles3();
            }

            canMove = true;
            canRotate = true;
        }

        // Lloyd as AI
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.1f && animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            swordCollider4.SetActive(false);
            leftfootCollider4.SetActive(false);
            rightfootCollider4.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            swordCollider4.SetActive(false);
            leftfootCollider4.SetActive(false);
            rightfootCollider4.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            swordCollider4.SetActive(false);
            leftfootCollider4.SetActive(false);
            rightfootCollider4.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            swordCollider4.SetActive(false);
            leftfootCollider4.SetActive(false);
            rightfootCollider4.SetActive(false);

            canMove = true;
            canRotate = true;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.065f && animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {
            if (GameManager.Instance.p2MP >= 20)
            {
                Projectiles4();
            }

            canMove = true;
            canRotate = true;
        }

        // AI can't move or rotate during the animation attacks is being played
        if (animateRex.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            lefthandCollider.SetActive(true);
            righthandCollider.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider.SetActive(true);
            righthandCollider.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            lefthandCollider.SetActive(true);
            righthandCollider.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateRex.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {
            
            
            canMove = false;
            canRotate = false;
        }

        if (animateKyle.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            lefthandCollider2.SetActive(true);
            righthandCollider2.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider2.SetActive(true);
            righthandCollider2.SetActive(true);


            canMove = false;
            canRotate = false;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            leftfootCollider2.SetActive(true);
            rightfootCollider2.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateKyle.GetCurrentAnimatorStateInfo(0).IsName("fireball"))
        {
            

            canMove = false;
            canRotate = false;
        }

        if (animateRobin.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            canMove = false;
            canRotate = false;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            lefthandCollider3.SetActive(true);
            righthandCollider3.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            leftfootCollider3.SetActive(true);
            rightfootCollider3.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateRobin.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {


            canMove = false;
            canRotate = false;
        }

        if (animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("basicattack"))
        {
            swordCollider4.SetActive(true);
            canMove = false;
            canRotate = false;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("dash"))
        {
            swordCollider4.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            leftfootCollider4.SetActive(true);
            rightfootCollider4.SetActive(true);

            canMove = false;
            canRotate = false;
        }
        if (animateLloyd.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {


            canMove = false;
            canRotate = false;
        }





        // If AI is on the ground and wants to peform a jump
        if (isGrounded)
        {
            velocity.y = 0;
            ableToMakeDoubleJump = true;
            
            if (jumpTime <= 0)
            {
                velocity.y = jumpForce;
                rb.AddForce(new Vector3(0, velocity.y, 0), ForceMode.Impulse);
                jump.Play();
                speed = 8;
                jumpTime = Random.Range(2, 9);

            }
        }
        else
        {
            // This only happens if the AI is not on the ground
            velocity.y += gravity * Time.deltaTime;
            animateRex.SetBool("crouch", false);
            animateKyle.SetBool("crouch", false);
            animateRobin.SetBool("crouch", false);
            animateLloyd.SetBool("crouch", false);
          
        }

        if (currentState == "ChaseState")
        {
            // Play the run animation while the AI is in Chase State

            // AI Rex in chasing state
            animateRex.SetTrigger("chase");
            animateRex.SetBool("isAttacking", false);

            // AI Kyle in chasing state
            animateKyle.SetTrigger("chase");
            animateKyle.SetBool("isAttacking", false);
            
            // AI Robin in chasing state
            animateRobin.SetTrigger("chase");
            animateRobin.SetBool("isAttacking", false);
            if (specialTime <= 0)
            {
                if(isGrounded)
                {
                    animateRobin.SetBool("shootingArrows", true);
                    specialTime = Random.Range(2, 9);
                }
                if(!isGrounded)
                {
                    specialTime = 0;
                }
              
            }
            if (specialTime > 0)
            {
                animateRobin.SetBool("shootingArrows", false);

            }


            // AI Lloyd in chasing state
            animateLloyd.SetTrigger("chase");
            animateLloyd.SetBool("isAttacking", false);

          

            // If AI is closer to the charatcer, the state will change to attack
            if (distance < attackRange)
                currentState = "AttackState";
            
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

            // AI Rex in attacking state
            animateRex.SetInteger("attackIndex", Random.Range(0, 4));
            animateRex.SetBool("isAttacking", true);

            // AI Kyle in attacking state
            animateKyle.SetInteger("attackIndex", Random.Range(0, 4));
            animateKyle.SetBool("isAttacking", true);

            // AI Robin in attacking state
            animateRobin.SetInteger("attackIndex", Random.Range(0, 4));
            animateRobin.SetBool("isAttacking", true);

            // Ai Lloyd in attacking state
            animateLloyd.SetInteger("attackIndex", Random.Range(0, 4));
            animateLloyd.SetBool("isAttacking", true);

            // If the AI is further away from the characters, the state will change to chase
            if (distance > attackRange)
                currentState = "ChaseState";
           
       
        }
        


    }

    public void Projectiles()
    {
        // AI Kyle's special projectiles   
        GameObject fireball = Instantiate(projectiles, projPoint.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().AddForce(projPoint.forward * projSpeed);
        GameManager.Instance.MPP2Adjustment(20);
        

        
    }

    public void Projectiles2()
    {
        // Ai Rex's special projectiles
        GameObject summon = Instantiate(projectiles2, projPoint2.position, Quaternion.identity);
        summon.GetComponent<Rigidbody>().AddForce(projPoint2.forward * projSpeed2);
        summon.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        GameManager.Instance.MPP2Adjustment(20);
        
        
    }
    public void Projectiles3()
    {
        // AI Robin's special projectiles
        GameObject barrow = Instantiate(projectiles3, projPoint3.position, Quaternion.identity);
        barrow.GetComponent<Rigidbody>().AddForce(projPoint3.forward * projSpeed3);
        barrow.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        GameManager.Instance.MPP2Adjustment(20);
        

    }
    public void Projectiles4()
    {
        // AI Lloyd's specail projectiles
        GameObject thunder = Instantiate(projectiles4, projPoint4.position, Quaternion.identity);
        thunder.GetComponent<Rigidbody>().AddForce(projPoint4.forward * projSpeed4);
        GameManager.Instance.MPP2Adjustment(20);
        

    }
    public void ProjectilesRobinAI()
    {
        // AI Robin's normal projectiles
        GameObject rarrow = Instantiate(projectilesRobin, projPointRobin.position, Quaternion.identity);
        rarrow.GetComponent<Rigidbody>().AddForce(projPointRobin.forward * projSpeedRobin);
        rarrow.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        
    }
}
