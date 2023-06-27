using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectiles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectiles;
    public Transform projPoint;

    public void Projectiles()
    {
        Instantiate(projectiles, projPoint.position, Quaternion.identity);
    }
}
