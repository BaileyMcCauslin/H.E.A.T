using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Figure8 props to https://forum.unity.com/threads/making-an-object-move-in-a-figure-8-programatically.38007/ CodeBear
public class AI : MonoBehaviour
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

        //Flip pattern determined by pub bools
        if (isLinkOffsetScalePositiveX)
            phase = 3.14f / 2f + 3.14f;
        else if (isLinkOffsetScaleNegativeX)
            phase = 3.14f / 2f;
        else if (isLinkOffsetScalePositiveZ)
            phase = 3.14f;
        else
            phase = 0;
    }

    void figureEight()
    {
        //Calculate where pivot is located
        pivotOffset = Vector3.forward * 2 * scaleZ;

        phase += speed * Time.deltaTime;

        //Check for pivot zone
        if (phase > m_2PI)
        {
            isInverted = !isInverted;
            phase -= m_2PI;
        }
        if (phase < 0)
        {
            phase += m_2PI;
        }

        //Rotate the tank based on where the tank is in circuit
        if (!isInverted)
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }

        Vector3 nextPosition = pivot + (isInverted ? pivotOffset : Vector3.zero);
        transform.position = new Vector3(nextPosition.x + Mathf.Sin(phase) * scaleX + offsetX, transform.position.y, nextPosition.z + Mathf.Cos(phase) * (isInverted ? -1 : 1) * scaleZ + offsetZ);
    }
}
