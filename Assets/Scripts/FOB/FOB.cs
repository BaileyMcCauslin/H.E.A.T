using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FOB : MonoBehaviour
{
  [ SerializeField ] private double health;
  private bool destroyed;

  void Awake()
  {
    health = 500;
    ShowStructure();
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
