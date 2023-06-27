using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetScript : MonoBehaviour
{

    public List<Transform> targets;

    public Vector3 offset;
    private float smoothTime = 0.3f;

    private float minimumZoom = 90f;
    private float maximumZoom = 26f;
    private float zoomLimiter = 50f;

    private Vector3 velocity;
    private Camera cam;


    void Start()
    {
        cam = GetComponent<Camera>();    
    }
    void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        // The function to allow to zoom in the players
        float newZoom = Mathf.Lerp(maximumZoom, minimumZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

    }


    void Move()
    {
        // The function to allow the camera to move by using the GetCenterPoint()
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }
    
    float GetGreatestDistance()
    {
        // The function to allow the camer to zoom while targeting on the player by using the distance between them
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }
    Vector3 GetCenterPoint()
    {
        // Allows the camera to move while targeting on the players
        if (targets.Count == 1)
        {
            return targets[0].position;

        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
