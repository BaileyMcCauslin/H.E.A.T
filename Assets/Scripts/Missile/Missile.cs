using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public float killTime = 0.0f;
    public float itemExpireTime = 5.0f;
    public float damage = 50;
    public int type = 0; //set to others when adding other missile types

    //Audio
    [SerializeField] private AudioSource explosionAudioSource;
    [SerializeField] private AudioClip explosionSound;

    void Awake() {
      explosionAudioSource = gameObject.AddComponent<AudioSource>();
      explosionAudioSource.clip = explosionSound;
      explosionAudioSource.volume = 1f;
    }

    void OnTriggerEnter(Collider collider)
    {
        explosionAudioSource.Play();
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        Debug.Log("HIT:  " + collider.gameObject);

        if (collider.gameObject.tag == "ai")
        {
            Debug.Log("Hit AI tag");
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
