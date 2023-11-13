using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectile : MonoBehaviour
{
    public GameObject missle;
    public float projectileVel = 3500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canShoot = CamSwitchManager.camViewChanged;
        if (!canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 barrelTipPosition = transform.position + transform.forward * 6.0f;
                GameObject currentProj = Instantiate(missle, barrelTipPosition, transform.rotation);
                currentProj.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                             (transform.position.x, Input.mousePosition.y, projectileVel));
            }
        }
    }
}
