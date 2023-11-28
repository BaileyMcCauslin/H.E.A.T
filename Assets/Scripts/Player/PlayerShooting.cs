using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [ SerializeField ] GameObject barrelShootingPosition;
    public GameObject missile;
    public float projectileVel = 3500.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool canShoot = CameraSwitchManager.camViewChanged;
        if (!canShoot)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject currentProj = Instantiate(missile, 
                                      barrelShootingPosition.transform.position, 
                                     barrelShootingPosition.transform.rotation);
                currentProj.GetComponent<Rigidbody>().AddRelativeForce(
                        new Vector3(transform.position.x, Input.mousePosition.y, 
                                                                projectileVel));
            }
        }
    }
}
