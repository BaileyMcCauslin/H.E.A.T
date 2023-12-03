using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILookAt : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //Always point AI at player
        Vector3 point = new Vector3(player.transform.position.x,
                                        player.transform.position.y,
                                            player.transform.position.z);
        transform.LookAt(point, Vector3.up);
    }
}
