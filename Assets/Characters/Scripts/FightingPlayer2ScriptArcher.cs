using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightingPlayer2ScriptArcher : MonoBehaviour
{
    public Animator animate;

    public float cooldownTime = 2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    private float lastClickedTime = 0;
    private float maxComboDelay = 1;

    // Hit Colliders
    public GameObject lefthandColiide;
    public GameObject righthandCollide;
    public GameObject leftfootCollide;
    public GameObject rightfootCollide;
    public GameObject headCollide;

    // Normal Projectiles
    // Special Mechianc
    public GameObject projectiles;
    public Transform projPoint;
    public float projSpeed = 600;

    // Special Mechianc
    public GameObject projectiles2;
    public Transform projPoint2;
    public float projSpeed2 = 600;

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

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("dashattack"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("downattack"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("airattack"))
        {

            PlayerController.Instance.canMove = false;
            PlayerController.Instance.canRotate = false;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).IsName("special"))
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

        // When the attacking animations has ended, the player is able to move or rotate
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit1"))
        {
            animate.SetBool("hit1", false);
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit2"))
        {
            animate.SetBool("hit2", false);
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("hit3"))
        {
            animate.SetBool("hit3", false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;

        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("dashattack"))
        {
            animate.SetBool("dashattack", false);
            rightfootCollide.SetActive(false);
            leftfootCollide.SetActive(false);
            noOfClicks = 0;
            PlayerController.Instance.canMove = true;
            PlayerController.Instance.canRotate = true;
        }
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("special"))
        {
            animate.SetBool("special", false);
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
        if (animate.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && animate.GetCurrentAnimatorStateInfo(0).IsName("airattack"))
        {
            animate.SetBool("airattack", false);
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
                    animate.SetBool("dashattack", true);
                    rightfootCollide.SetActive(true);
                    leftfootCollide.SetActive(true);
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
                    // Air Attack - the function will only play when the characyer is falling
                    animate.SetBool("airattack", true);
                    rightfootCollide.SetActive(true);
                    leftfootCollide.SetActive(true);
                }



            }
            //player's special attack
            if (specialAttack)
            {
                if (GameManager.Instance.p2MP >= 20)
                {
                    onFire();
                    PlayerController.Instance.canMove = false;
                    PlayerController.Instance.canRotate = false;
                }

            }
        }
    }

    void OnClick()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            animate.SetBool("hit1", true);

        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 1);

    }

    void onFire()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            animate.SetBool("special", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 1);
    }


    public void Projectiles()
    {
        GameObject arrow = Instantiate(projectiles, projPoint.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody>().AddForce(projPoint.forward * projSpeed);
        arrow.transform.rotation = Quaternion.Euler(90f, 0f, 90f);


    }

    public void Projectiles2()
    {
        GameObject strongArrow = Instantiate(projectiles2, projPoint2.position, Quaternion.identity);
        strongArrow.GetComponent<Rigidbody>().AddForce(projPoint2.forward * projSpeed2);
        strongArrow.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        GameManager.Instance.MPP2Adjustment(20);
    }
}
