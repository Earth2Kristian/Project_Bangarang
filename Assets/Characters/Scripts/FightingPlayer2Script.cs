using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightingPlayer2Script : MonoBehaviour
{
    public Animator animate;

    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public float noOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 1;

    // Hit Colliders
    public GameObject lefthandColiide;
    public GameObject righthandCollide;
    public GameObject leftfootCollide;
    public GameObject rightfootCollide;
    public GameObject headCollide;

    // Special Mechianc
    public GameObject projectiles;
    public Transform projPoint;
    public float projSpeed = 600;

    private bool normalAttack = false;
    private bool specialAttack = false;
    void Start()
    {
        animate.GetComponent<Animator>();

    }

    public void OnNormal(InputAction.CallbackContext context)
    {
        normalAttack = context.action.triggered;
        normalAttack = context.performed;
    }
    public void OnSpecial(InputAction.CallbackContext context)
    {

        specialAttack = context.action.triggered;
        specialAttack = context.performed;
    }

    void Update()
    {
        // When the attacking animations has started, the character is unable move or rotate
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            //animate.SetBool("hit2", true);
            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            //animate.SetBool("hit3", true);
            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("flipkick"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("fireball"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }

        // These are to make the character more stable during the match
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("double jump"))
        {
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }


        // When the attacking animations has ended, the character is able to move or rotate
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            animate.SetBool("hit1", false);
            lefthandColiide.SetActive(false);
            noOfClicks = 1;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            animate.SetBool("hit2", false);
            righthandCollide.SetActive(false);
            noOfClicks = 2;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            animate.SetBool("hit3", false);
            noOfClicks = 0;
            leftfootCollide.SetActive(false);
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("roll"))
        {
            animate.SetBool("roll", false);
            headCollide.SetActive(false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("fireball"))
        {
            animate.SetBool("fireball", false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {
            animate.SetBool("downattack", false);
            rightfootCollide.SetActive(false);
            leftfootCollide.SetActive(false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("flipkick"))
        {
            animate.SetBool("flipkick", false);
            rightfootCollide.SetActive(false);
            leftfootCollide.SetActive(false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }

        // ------------------------------------------------------------------------------------------------------------------
        // CHARACTER'S MOVESET COMMANDS
        // ------------------------------------------------------------------------------------------------------------------
        if (Time.time > nextFireTime)
        {
            // Character's Basic Attacks
            if (normalAttack)
            {

                if (animate.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                {
                    // Netural Attack -  the function will only play when the character is standing
                    OnClick();
                }
                if (animate.GetCurrentAnimatorStateInfo(0).IsName("run"))
                {
                    // Side Attack - the function will only play when the character is running
                    animate.SetBool("roll", true);
                    headCollide.SetActive(true);
                }
                if (animate.GetCurrentAnimatorStateInfo(0).IsName("crouch"))
                {
                    // Down Attack - the function will only play when the character is crouching
                    animate.SetBool("downattack", true);
                    rightfootCollide.SetActive(true);
                    leftfootCollide.SetActive(true);
                }
                if (animate.GetCurrentAnimatorStateInfo(0).IsName("jump") || animate.GetCurrentAnimatorStateInfo(0).IsName("double jump"))
                {
                    // Air Attack - the function will only play when the character is falling
                    animate.SetBool("flipkick", true);
                    rightfootCollide.SetActive(true);
                    leftfootCollide.SetActive(true);
                }
            }

            // Character's Special Mechanic
            if (specialAttack)
            {
                if (GameManager.Instance.p2MP >= 20)
                {
                    animate.SetBool("fireball", true);
                    PlayerController.Instance.canMove = false;
                    PlayerController.Instance.canRotate = false;
                }

            }
        }
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        if (noOfClicks == 0)
        {
            animate.SetBool("hit1", true);
            lefthandColiide.SetActive(true);
        }
        

        if (noOfClicks == 1)
        {
            animate.SetBool("hit1", false);
            animate.SetBool("hit2", true);
            righthandCollide.SetActive(true);
        }
        if (noOfClicks == 2)
        {
            animate.SetBool("hit2", false);
            animate.SetBool("hit3", true);
            leftfootCollide.SetActive(true);
            noOfClicks = 0;
        }
        
    }

    public void Projectiles()
    {
        GameObject fireball = Instantiate(projectiles, projPoint.position, Quaternion.identity);
        fireball.GetComponent<Rigidbody>().AddForce(projPoint.forward * projSpeed);
        GameManager.Instance.MPP2Adjustment(20);
    }

}
