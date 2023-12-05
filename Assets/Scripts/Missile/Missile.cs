using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float killTime = 0.0f;
    public float itemExpireTime = 5.0f;
    public float damage = 50;
    public int type = 0; //set to others when adding other missile types

    void OnCollisionEnter(Collision collision)
    {
        print("HIT:  " + collision.gameObject);

        if (collision.gameObject.tag == "ai")
        {
            print("Hit AI tag");
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        killTime += Time.deltaTime;

        if (killTime >= itemExpireTime)
        {
            Destroy(gameObject);
        }
    }
}
