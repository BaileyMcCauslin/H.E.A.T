using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [ SerializeField ] float moveSpeed;
    [ SerializeField ] float horizontalInput;
    [ SerializeField ] float verticalInput;
    Rigidbody playerRB;
    public Camera cam;
    public float turnSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
        {
        // Get the rigid body of the object this script is attached to
        playerRB = GetComponent<Rigidbody>();
        }

    // Update is called once per frame
    void Update()
    {
        bool cantMove = CamSwitchManager.camViewChanged;

        // Move player horizontally with impulse
        if (!cantMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
            }

            // Set input variables to adequate input
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            playerRB.MovePosition( playerRB.position + 
           ( moveSpeed * Time.deltaTime * verticalInput * transform.forward ) );

            // playerRB.AddForce(Vector3.right * horizontalInput * Time.deltaTime
            //                                            * moveSpeed, ForceMode.Impulse);

            // // Move player vertically with impulse
            // playerRB.AddForce(Vector3.forward * verticalInput * Time.deltaTime
            //                                            * moveSpeed, ForceMode.Impulse);
        }
    }

}
