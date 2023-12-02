using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    public float panSpeed = 10f;
    public float panBorderThickness = 10f;

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        // Move the camera when the mouse hits the edge of the screen
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.fixedDeltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.fixedDeltaTime;
        }

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.fixedDeltaTime;
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.fixedDeltaTime;
        }

        transform.position = pos;
    }
    
}