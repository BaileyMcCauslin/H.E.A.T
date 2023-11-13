using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [ SerializeField ] GameObject player;
    [ SerializeField ] float yOffset;
    [ SerializeField ] float zOffset;
    [ SerializeField ] float lerpEasiness;

    Vector3 startPosition;
    public float minFov = 15f;
    public float maxFov = 90f;
    public float sensitivity = 10f;

    // Start is called before the first frame update
    void Start()
        {
        
        }

    void Update()
        {
        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;
        }

    // Update is called once per frame
    void FixedUpdate()
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
