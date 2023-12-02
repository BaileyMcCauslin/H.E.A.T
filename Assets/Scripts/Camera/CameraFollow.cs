using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
    {
    [ SerializeField ] GameObject player;
    [ SerializeField ] float yOffset;
    [ SerializeField ] float zOffset;
    [ SerializeField ] float lerpEasiness;

    // Update is called once per frame
    void FixedUpdate()
        {
        // Set camera position at player's position with addition of offsets
        Vector3 newPosition = new Vector3( player.transform.position.x, 
                                          player.transform.position.y + yOffset, 
                                        player.transform.position.z + zOffset );

        // Move/interpolate current camera position to new position
        transform.position = Vector3.Lerp( transform.position, newPosition, 
                                                                 lerpEasiness );
        }

    }
