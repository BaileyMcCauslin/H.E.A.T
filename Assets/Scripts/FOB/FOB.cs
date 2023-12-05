using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FOB : MonoBehaviour
{
  [ SerializeField ] private double health;
  private bool destroyed;
  public Image healthBar;
  public Image background;
  private RectTransform rectTransform;
  private RectTransform backRectTrans;
    public Canvas canvas;

  void Awake()
  {
    health = 500;
    ShowStructure();
    rectTransform = healthBar.GetComponent<RectTransform>();
    backRectTrans = background.GetComponent<RectTransform>();
  }

  void Update()
  {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 50f);
        List<Collider> playerColliders = new List<Collider>();

        foreach (Collider collider in hitColliders)
        {
            GameObject colliderGameObject = collider.gameObject;

            if (colliderGameObject.CompareTag("Player"))
            {
                // Append the collider to the list
                playerColliders.Add(collider);
            }
        }
        Collider[] playerCollidersArray = playerColliders.ToArray();

        if (playerCollidersArray.Length != 0)
        {
            canvas.enabled = true;
            Vector3 worldPosition = transform.position;
            worldPosition.y += 3.0f;
            Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);
            rectTransform.position = screenPos;
            backRectTrans.position = screenPos;
        }
        else
        {
            canvas.enabled = false;
        }
  }

  void OnTriggerEnter(Collider collider) {
    // print("FOB collision detected");

    GameObject collisionObject = collider.gameObject;
    print(collisionObject);
    Missile missile = collider.gameObject.GetComponent<Missile>();
    
    //check to see if collision was with a missile
    if (missile != null) {
      health -= missile.damage;
      // print(gameObject.name + " took " + missile.damage + " damage.\nRemaining health: " + health);
      
      if (health <= 0) {
        this.destroyed = true;
        ShowDestroyed();
      }
    }

    if (this.destroyed) {
      // This should take players to some end game screen showing the winner.
      // For now just goes to main menu.
      if (this.gameObject.tag == "Enemy") {
        GameManager.manager.EndGame(true);
      }
      else {
        print("Player FOB destroyed");
        GameManager.manager.EndGame(false);
      }
    }

    Destroy(collider.gameObject);
  }

  private void ShowDestroyed() {
    foreach (Transform child in transform) {
      if (child.name == "Structure") {
        child.gameObject.SetActive(false);
      }
      else if (child.name == "Destroyed") {
        child.gameObject.SetActive(true);
      }
    }
  }

  private void ShowStructure() {
    foreach (Transform child in transform) {
      if (child.name == "Structure") {
        child.gameObject.SetActive(true);
      }
      else if (child.name == "Destroyed") {
        child.gameObject.SetActive(false);
      }
    }

    destroyed = false;
  }
}
