using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    //Fig 8 info
    public float speed = 2;
    public float scaleX = 2;
    public float scaleZ = 3;
    public float offsetX = 0;
    public float offsetZ = 0;

    //For fig 8 config 
    public bool isLinkOffsetScalePositiveX = false;
    public bool isLinkOffsetScaleNegativeX = false;
    public bool isLinkOffsetScalePositiveZ = false;
    public bool isLinkOffsetScaleNegativeZ = false;

    private float phase;
    private float m_2PI = Mathf.PI * 2;

    //Get pos of pivot and original pos
    private Vector3 originalPosition;
    private Vector3 pivot;
    private Vector3 pivotOffset;

    //Check for pivot turn
    private bool isInverted = false;

    //Get ai rigid body
    Rigidbody aiRB;

    //Determine how fast ai turn
    public float turnSpeed = 10.0f;

    public float timeBetweenStops = 5.0f;
    private float stopTimer = 0.0f;
    private bool isStopped = false;

    void Start()
    {
        aiRB = GetComponent<Rigidbody>();
        startFigureEight();
    }

    void Update()
    {
        figureEight();
    }

    void startFigureEight()
    {
        pivot = transform.position;
        originalPosition = transform.position;

        // Flip pattern determined by pub bools
        if (isLinkOffsetScalePositiveX)
            phase = Mathf.PI / 2f + Mathf.PI;
        else if (isLinkOffsetScaleNegativeX)
            phase = Mathf.PI / 2f;
        else if (isLinkOffsetScalePositiveZ)
            phase = Mathf.PI;
        else
            phase = 0;
    }

    void figureEight()
    {
        if (!isStopped)
        {
            // Calculate where pivot is located
            pivotOffset = Vector3.forward * 2 * scaleZ;

            phase += speed * Time.deltaTime;

            // Check for pivot zone
            if (phase > m_2PI)
            {
                isInverted = !isInverted;
                phase -= m_2PI;
            }
            if (phase < 0)
            {
                phase += m_2PI;
            }

            // Rotate the tank based on constant turn speed
            float rotateAmount = turnSpeed * Time.deltaTime;
            aiRB.MoveRotation(aiRB.rotation * Quaternion.Euler(0f, rotateAmount, 0f));

            // Move the tank forward with constant speed
            Vector3 nextPosition = pivot + (isInverted ? pivotOffset : Vector3.zero);
            aiRB.MovePosition(new Vector3(nextPosition.x + Mathf.Sin(phase) * scaleX + offsetX, aiRB.position.y, nextPosition.z + Mathf.Cos(phase) * (isInverted ? -1 : 1) * scaleZ + offsetZ));
        }

        // Update the stop timer
        stopTimer += Time.deltaTime;

        // Check if it's time to stop or resume
        if (stopTimer >= timeBetweenStops)
        {
            isStopped = !isStopped;  // Toggle between stopped and not stopped
            stopTimer = 0.0f;  // Reset the timer
        }
    }

}
