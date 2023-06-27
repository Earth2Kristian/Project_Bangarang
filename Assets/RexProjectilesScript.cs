using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RexProjectilesScript : MonoBehaviour
{
    public Transform user;
    public float distance;
    public float speed = 6;
    //public float timeLimit = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //distance = Vector3.Distance(transform.position, target.transform.position);

        if (user.position.x < transform.position.x)
        {
            // Move right while facing right
            transform.Translate(transform.right * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 90f, 0);
            


        }
        else if (user.position.x > transform.position.x)
        {
   
           transform.Translate(-transform.right * speed * Time.deltaTime);
           transform.rotation = Quaternion.Euler(0, 270f, 0);


        }
    }
}
