using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIForceJumpScript : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 direction;
    public AudioSource jump;
    public float jumpForce = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AI"))
        {
            direction.y = jumpForce;
            rb.AddForce(new Vector3(0, direction.y, 0), ForceMode.Impulse);
            jump.Play();

        }
    }

}
