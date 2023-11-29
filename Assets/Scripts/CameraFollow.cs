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

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private bool mouseMove;

    // Start is called before the first frame update
    void Start()
    {
        mouseMove = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Z) && !mouseMove)
        {
            mouseMove = true;
        }
        else if (Input.GetKey(KeyCode.Z) && mouseMove)
        {
            mouseMove = false;
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        if (mouseMove)
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Every update set back to player
        setBackToPlayer();
    }

    void setBackToPlayer()
    {
        // Set camera position at player's position with addition of offsets
        Vector3 newPosition = new Vector3(player.transform.position.x,
                                  player.transform.position.y + yOffset,
                                player.transform.position.z + zOffset);

        // Check if the camera flag is true

        // Move/interpolate current camera position to new position
        transform.position = Vector3.Lerp(transform.position, newPosition,
                                                                lerpEasiness);
    }

}
