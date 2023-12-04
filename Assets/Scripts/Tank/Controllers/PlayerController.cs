using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    {
    [ SerializeField ] float moveSpeed;
    [ SerializeField ] float horizontalInput;
    [ SerializeField ] float verticalInput;
    [ SerializeField ] float maxSpeed;
    [ SerializeField ]public Tank tank;
    Rigidbody playerRB;
    public float turnSpeed = 10.0f;

    public AudioClip idleEngineSound;
    public AudioClip drivingEngineSound;
    private AudioSource idleEngineAudioSource;
    private AudioSource drivingEngineAudioSource;

    bool isLeftKeyPressed;
    bool isRightKeyPressed;
    bool isUpKeyPressed;
    bool isDownKeyPressed;

    // Start is called before the first frame update
    void Start()
        {
        // Get the rigid body of the object this script is attached to
        playerRB = GetComponent<Rigidbody>();

        // initialize audio sources
        idleEngineAudioSource = gameObject.AddComponent<AudioSource>();
        idleEngineAudioSource.clip = idleEngineSound;
        idleEngineAudioSource.loop = true;
        idleEngineAudioSource.volume = 0.01f;

        drivingEngineAudioSource = gameObject.AddComponent<AudioSource>();
        drivingEngineAudioSource.clip = drivingEngineSound;
        drivingEngineAudioSource.loop = true;
        drivingEngineAudioSource.volume = 0.01f;

        // Check if specific keys are pressed
        isLeftKeyPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightKeyPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpKeyPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        isDownKeyPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        }

    void Update() {
      if (Input.GetKeyDown(KeyCode.RightAlt) || Input.GetKeyDown(KeyCode.LeftAlt)) {
        if (tank.activeMissile == (int)Tank.MISSILE_TYPES.heat) {  
          tank.activeMissile = 0;
        }
        else {
          tank.activeMissile += 1;
          return;
        }
      }

      if (Input.GetMouseButtonDown(0)) {
        tank.ShootMissle();
      }
    }

    void FixedUpdate()
        {
        // Set input variables to adequate input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check if specific keys are pressed
        isLeftKeyPressed = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        isRightKeyPressed = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        isUpKeyPressed = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
        isDownKeyPressed = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);

        // Check if player DID NOT change their camera view
        if( !CameraSwitchManager.camViewChanged )
            {
            // Check if tank has not reached maximum speed
            if( playerRB.velocity.magnitude < maxSpeed )
                {
                // Move player vertically with impulse
                playerRB.AddForce( moveSpeed * playerRB.mass * Time.fixedDeltaTime * 
                         verticalInput * transform.forward, ForceMode.Impulse );
                }

            // Rotate player to either left or right depending on input
            transform.Rotate( Vector3.up * turnSpeed * Time.fixedDeltaTime 
                                                            * horizontalInput );
            }

          // check for tank moving to play sound
          if(isDownKeyPressed || isLeftKeyPressed || isRightKeyPressed || isUpKeyPressed)
          {
            if (!drivingEngineAudioSource.isPlaying)
            {
              drivingEngineAudioSource.Play();
              idleEngineAudioSource.Stop();
            }
          }
          else if(!idleEngineAudioSource.isPlaying)
          {
            drivingEngineAudioSource.Stop();
            idleEngineAudioSource.Play();
          }

        }

    // On Collision Enter Function
    void OnCollisionEnter( Collision other )
        {
          print("Tank collided with " + other.gameObject);
        // Check if game object colliding has a mesh collider
        if( other.gameObject.GetComponent<MeshCollider>() != null )
            {
            // Freeze the player's/tank's rotations
            playerRB.constraints = RigidbodyConstraints.FreezeRotation;
            }

        }

    // On Collision Leave Function
    void OnCollisionExit( Collision other )
        {
        // Unfreeze the player's/tank's rotations
        playerRB.constraints = RigidbodyConstraints.None;
        }

    }