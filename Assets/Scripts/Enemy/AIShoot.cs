using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    [SerializeField] public GameObject missile;
    public float projectileVel = 3500.0f;
    public float fireRate = 2f;
    private float nextFireTime = 0.0f;
    public float shootRadius = 50.0f;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Access the GameObject to which this script is attached
        GameObject myGameObject = gameObject;

        // You can now perform operations on myGameObject
        // Debug.Log("This script is attached to: " + myGameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, shootRadius);
        List<Collider> playerColliders = new List<Collider>();

        foreach (Collider collider in hitColliders)
        {
            GameObject colliderGameObject = collider.gameObject;

            if (colliderGameObject.CompareTag("Player"))
            {
                // Append the collider to the list
                print("AI detected player");
                playerColliders.Add(collider);
            }
        }
        Collider[] playerCollidersArray = playerColliders.ToArray();

        if (playerCollidersArray.Length != 0)
        {
            // print("Player in collider array");
            // print("next fire time: " + nextFireTime);
            // print("Time: " + Time.time);
            canvas.enabled = true;
            if (Time.time > nextFireTime)
            {
                // print("AI firing");
                nextFireTime = Time.time + fireRate;
                // print("set next fire time: " + nextFireTime);
                Vector3 barrelTipPosition = transform.position + transform.forward * 6.0f;
                GameObject currentProj = Instantiate(missile, barrelTipPosition, transform.rotation);
                currentProj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                                (transform.position.x, transform.position.y, projectileVel));

                // print("Enemy missile: " + currentProj);
            }
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
