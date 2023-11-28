using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
            // Access the GameObject to which this script is attached
        GameObject myGameObject = gameObject;

        // You can now perform operations on myGameObject
        Debug.Log("This script is attached to: " + myGameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        bool cantMove = CamSwitchManager.camViewChanged;
        if (!cantMove)
        {
            Vector3 point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
            float t = cam.transform.position.y / (cam.transform.position.y - point.y);
            Vector3 finalPoint = new Vector3(t * (point.x - cam.transform.position.x) + cam.transform.position.x, transform.position.y, t * (point.z - cam.transform.position.z) + cam.transform.position.z);

            transform.LookAt(finalPoint, Vector3.up);
        }
    }
}
