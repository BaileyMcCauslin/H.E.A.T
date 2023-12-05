using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float killTime = 0.0f;
    public float itemExpireTime = 5.0f;
    
    void Update()
    {
      killTime += Time.deltaTime;

        if (killTime >= itemExpireTime)
        {
            Destroy(gameObject);
        } 
    }
}
