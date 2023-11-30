using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float killTime = 0.0f;
    public float itemExpireTime = 5.0f;
    public double damage = 50;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Debug.Log("HIT");
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
