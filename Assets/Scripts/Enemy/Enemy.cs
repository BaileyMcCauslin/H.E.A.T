using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float maxHealth = 200.0f;
    private float currentHealth;
    public Image healthBar;
    public Image background;
    private RectTransform rectTransform;
    private RectTransform backRectTrans; 

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rectTransform = healthBar.GetComponent<RectTransform>();
        backRectTrans = background.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if( currentHealth == 0 )
        {
            Destroy(gameObject);
        }

        Vector3 worldPosition = transform.position;
        worldPosition.y += 2.0f;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
        rectTransform.position = screenPos;
        backRectTrans.position = screenPos;
    }

    void OnTriggerEnter(Collider collide)
    {
        // Get the GameObject that collided with this object
        GameObject collidingObject = collide.gameObject;

        // Check if the colliding object has the "player_missile" tag
        if (collidingObject.CompareTag("player_missle"))
        {
            currentHealth -= 50;
            rectTransform.sizeDelta = new Vector2(rectTransform.rect.width - 40, rectTransform.rect.height);
        }
    }
}
