using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRoam : MonoBehaviour
{
    [ SerializeField ] GameObject player;
    [ SerializeField ] float yOffset;
    [ SerializeField ] float zOffset;

    [ SerializeField ] float lerpEasiness;

    public float camSpeed = 20;
    public float screenSizeThickness = 10;


    // Update is called once per frame
    public float panSpeed = 10f;
    public float panBorderThickness = 10f;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
                    // Set camera position at player's position with addition of offsets
        Vector3 newPosition = new Vector3( player.transform.position.x, 
                                          player.transform.position.y + yOffset, 
                                        player.transform.position.z + zOffset );

        // Check if the camera flag is true

        // Move/interpolate current camera position to new position
        transform.position = Vector3.Lerp( transform.position, newPosition, 
                                                                lerpEasiness );
        }
    }


    void Update()
    {
        Vector3 pos = transform.position;

        // Move the camera when the mouse hits the edge of the screen
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        if (Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
