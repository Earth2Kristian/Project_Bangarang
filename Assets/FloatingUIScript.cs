using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUIScript : MonoBehaviour
{
    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        Vector3 pos = cam.WorldToScreenPoint(lookAt.position + offset);

        if (transform.position != pos)
            transform.position = pos;
    }
}
